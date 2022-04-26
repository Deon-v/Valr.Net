using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using Valr.Net.Clients.GeneralApi;
using Valr.Net.Clients.SpotApi;
using Valr.Net.Enums;
using Valr.Net.Interfaces.Clients;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Interfaces.Clients.SpotApi;
using Valr.Net.Objects.Models.General.Streams;
using Valr.Net.Objects.Options;

namespace Valr.Net.Clients
{
    public class ValrSocketClient : BaseSocketClient, IValrSocketClient
    {
        #region Api clients
        public IValrSocketClientSpotStreams SpotStreams { get; }
        public IValrSocketClientGeneralStreams GeneralStreams { get; }
        #endregion

        /// <summary>
        /// Create a new instance of ValrSocketClientSpot with default options
        /// </summary>
        public ValrSocketClient() : this(ValrSocketClientOptions.Default)
        {
        }

        public ValrSocketClient(ValrSocketClientOptions options) : base("Valr", options)
        {
            SpotStreams = new ValrSocketClientSpotStreams(log, this, options);
            GeneralStreams = new ValrSocketClientGeneralStreams(log, this, options);

            AddGenericHandler("Pong", (messageEvent) => { });

            SendPeriodic("Ping", TimeSpan.FromSeconds(30), con => new
            {
                type = "PING"
            });
        }

        public double IncomingKbps => throw new NotImplementedException();

        #region methods

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="options">Options to use as default</param>
        public static void SetDefaultOptions(ValrSocketClientOptions options)
        {
            ValrSocketClientOptions.Default = options;
        }

        internal CallResult<T> DeserializeInternal<T>(JToken obj, JsonSerializer? serializer = null, int? requestId = null)
            => Deserialize<T>(obj, serializer, requestId);

        internal Task<CallResult<UpdateSubscription>> SubscribeInternal<T>(SocketApiClient apiClient, string url, ValrSocketOutboundEvent _event, string[] pair, Action<DataEvent<T>> onData, CancellationToken ct, bool authenticated = false)
        {
            var request = new ValrSocketRequest
            {
                EventType = ValrSocketEventType.SUBSCRIBE,
                Subscriptions = new[]
                {
                    new Subscription
                    {
                        Event = _event,
                        pairs = pair

                    }
                }
            };

            return SubscribeAsync(apiClient, url, request, null, authenticated, onData, ct);
        }

        internal Task<CallResult<UpdateSubscription>> SubscribeInternalNoRequest<T>(SocketApiClient apiClient, string url, Action<DataEvent<T>> onData,
            CancellationToken ct, bool authenticated = false)
        {
            return SubscribeAsync(apiClient, url, new
            {
                type = "PING"
            }, null, authenticated, onData, ct);
        }

        /// <inheritdoc />
        protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, [NotNullWhen(true)] out CallResult<T>? callResult)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override bool HandleSubscriptionResponse(SocketConnection s, SocketSubscription subscription, object request, JToken message, out CallResult<object>? callResult)
        {
            callResult = null;
            if (message.Type != JTokenType.Object)
                return false;

            var type = message["type"];
            if (type == null)
                return false;

            var result = message["message"];
            if (result != null && result.Type != JTokenType.Null)
            {
                log.Write(LogLevel.Trace, $"Socket {s.Socket.Id} Subscription completed");
                callResult = new CallResult<object>(new object());
                return true;
            }

            var error = message["error"];
            if (error == null)
            {
                callResult = new CallResult<object>(new ServerError("Unknown error: " + message));
                return true;
            }

            callResult = new CallResult<object>(new ServerError(error["code"]!.Value<int>(), error["msg"]!.ToString()));
            return true;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
        {
            if (message.Type != JTokenType.Object)
                return false;

            var parsedRequest = (ValrSocketRequest)request;
            var stream = message["type"].Value<string>();

            bool parsed = Enum.TryParse(stream, false, out ValrSocketInboundEvent inboundEvent);
            ValrSocketOutboundEvent outboundEvent = parsedRequest.Subscriptions[0].Event;
            if (!parsed)
                return false;

            return MatchInboundToOutboundEvents(outboundEvent, inboundEvent);
        }

        private static bool MatchInboundToOutboundEvents(ValrSocketOutboundEvent outboundEvent,
            ValrSocketInboundEvent inboundEvent)
        {
            switch (outboundEvent)
            {
                case ValrSocketOutboundEvent.AGGREGATED_ORDERBOOK_UPDATE:
                    {
                        if (inboundEvent is ValrSocketInboundEvent.AGGREGATED_ORDERBOOK_SNAPSHOT or
                            ValrSocketInboundEvent.AGGREGATED_ORDERBOOK_UPDATE)
                            return true;
                        break;
                    }
                case ValrSocketOutboundEvent.FULL_ORDERBOOK_UPDATE:
                    {
                        if (inboundEvent is ValrSocketInboundEvent.FULL_ORDERBOOK_SNAPSHOT
                            or ValrSocketInboundEvent.FULL_ORDERBOOK_UPDATE)
                            return true;
                        break;
                    }
                case ValrSocketOutboundEvent.MARKET_SUMMARY_UPDATE:
                    {
                        if (inboundEvent is ValrSocketInboundEvent.MARKET_SUMMARY_UPDATE)
                            return true;
                        break;
                    }
                case ValrSocketOutboundEvent.NEW_TRADE_BUCKET:
                    {
                        if (inboundEvent is ValrSocketInboundEvent.NEW_TRADE_BUCKET)
                            return true;
                        break;
                    }
                case ValrSocketOutboundEvent.NEW_TRADE:
                    {
                        if (inboundEvent is ValrSocketInboundEvent.NEW_TRADE)
                            return true;
                        break;
                    }
            }

            return false;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier)
        {
            return true;
        }

        /// <inheritdoc />
        protected override async Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection s)
        {
            if (s.ApiClient.AuthenticationProvider == null)
                return new CallResult<bool>(new NoApiCredentialsError());


            return new CallResult<bool>(true);
        }

        /// <summary>
        /// Gets a connection for a new subscription or query. Can be an existing if there are open position or a new one.
        /// </summary>
        /// <param name="apiClient">The API client the connection is for</param>
        /// <param name="address">The address the socket is for</param>
        /// <param name="authenticated">Whether the socket should be authenticated</param>
        /// <returns></returns>
        protected override SocketConnection GetSocketConnection(SocketApiClient apiClient, string address, bool authenticated)
        {
            var socketResult = sockets.Where(s => s.Value.Socket.Url.TrimEnd('/') == address.TrimEnd('/')
                                                  && (s.Value.ApiClient.GetType() == apiClient.GetType())
                                                  && (s.Value.Authenticated == authenticated || !authenticated) && s.Value.Connected).OrderBy(s => s.Value.SubscriptionCount).FirstOrDefault();
            var result = socketResult.Equals(default(KeyValuePair<int, SocketConnection>)) ? null : socketResult.Value;
            if (result != null)
            {
                if (result.SubscriptionCount < ClientOptions.SocketSubscriptionsCombineTarget || (sockets.Count >= MaxSocketConnections && sockets.All(s => s.Value.SubscriptionCount >= ClientOptions.SocketSubscriptionsCombineTarget)))
                {
                    // Use existing socket if it has less than target connections OR it has the least connections and we can't make new
                    return result;
                }
            }

            // Create new socket
            IWebsocket socket = authenticated ? CreateSocket(address, apiClient) : CreateSocket(address);

            var socketConnection = new SocketConnection(this, apiClient, socket);
            socketConnection.UnhandledMessage += HandleUnhandledMessage;
            foreach (var kvp in genericHandlers)
            {
                var handler = SocketSubscription.CreateForIdentifier(NextId(), kvp.Key, false, kvp.Value);
                socketConnection.AddSubscription(handler);
            }

            return socketConnection;
        }

        /// <summary>
        /// Create a socket for an address
        /// </summary>
        /// <param name="address">The address the socket should connect to</param>
        /// <param name="apiClient">The base api client with the Api credentials</param>
        /// <returns></returns>
        private IWebsocket CreateSocket(string address, BaseApiClient apiClient)
        {
            var socket = SocketFactory.CreateWebsocket(log, address, new Dictionary<string, string>(), GetAuthHeaders("/ws/account", apiClient));
            log.Write(LogLevel.Debug, $"Socket {socket.Id} new socket created for " + address);

            if (ClientOptions.Proxy != null)
                socket.SetProxy(ClientOptions.Proxy);

            socket.Timeout = ClientOptions.SocketNoDataTimeout;
            socket.DataInterpreterBytes = dataInterpreterBytes;
            socket.DataInterpreterString = dataInterpreterString;
            socket.RatelimitPerSecond = RateLimitPerSocketPerSecond;
            socket.OnError += e =>
            {
                if (e is WebSocketException wse)
                    log.Write(LogLevel.Warning, $"Socket {socket.Id} error: Websocket error code {wse.WebSocketErrorCode}, details: " + e.ToLogString());
                else
                    log.Write(LogLevel.Warning, $"Socket {socket.Id} error: " + e.ToLogString());
            };
            return socket;
        }

        private Dictionary<string, string> GetAuthHeaders(string path, BaseApiClient apiClient)
        {
            if (apiClient.AuthenticationProvider!.Credentials.Key == null || apiClient.AuthenticationProvider.Credentials.Secret == null)
                throw new ArgumentException("ApiKey/Secret not provided");

            var headers = ((ValrAuthenticationProvider)apiClient.AuthenticationProvider).GetAuthenticationHeaders(path);
            return headers;
        }

        /// <inheritdoc />
        protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscription)
        {

            var unsub = new ValrSocketRequest { EventType = ValrSocketEventType.SUBSCRIBE, Subscriptions = Array.Empty<Subscription>() };
            var result = false;

            if (!connection.Socket.IsOpen)
                return true;

            await connection.SendAndWaitAsync(unsub, ClientOptions.SocketResponseTimeout, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var id = data["id"];
                if (id == null)
                    return false;

                var result = data["result"];
                if (result?.Type == JTokenType.Null)
                {
                    result = true;
                    return true;
                }

                return true;
            }).ConfigureAwait(false);
            return result;
        }
        #endregion
    }
}
