using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public BaseSocketClientOptions ClientOptions => throw new NotImplementedException();

        /// <summary>
        /// Create a new instance of BinanceSocketClientSpot with default options
        /// </summary>
        public ValrSocketClient() : this(ValrSocketClientOptions.Default)
        {
        }

        public ValrSocketClient(ValrSocketClientOptions options) : base("Valr", options)
        {
            SpotStreams = new ValrSocketClientSpotStreams(log, this, options);
            GeneralStreams = new ValrSocketClientGeneralStreams(log, this, options);
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

        internal Task<CallResult<UpdateSubscription>> SubscribeInternal<T>(SocketApiClient apiClient, string url, string _event, string pair, Action<DataEvent<T>> onData, CancellationToken ct, bool authenticated = false)
        {
            var request = new ValrSocketRequest
            {
                type = ValrSocketEventType.SUBSCRIBE,
                subscriptions = new[]
                {
                    new Subscription
                    {
                        @event = _event,
                        pairs = new[]
                        {
                            pair
                        }
                    }
                }
            };

            return SubscribeAsync(apiClient, url, request, null, authenticated, onData, ct);
        }

        internal Task<CallResult<UpdateSubscription>> SendPing<T>(SocketApiClient apiClient, string url, Action<DataEvent<T>> onData,
            CancellationToken ct, bool authenticated = false)
        {
            dynamic request = new
            {
                type = "PING"
            };

            return SubscribeAsync(apiClient, url, request, null, authenticated, onData, ct);
        }

        /// <inheritdoc />
        protected override bool HandleQueryResponse<T>(SocketApiClient apiClient, SocketConnection s, object request, JToken data, out CallResult<T> callResult)
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

            var bRequest = (BinanceSocketRequest)request;
            if ((int)id != bRequest.Id)
                return false;

            var result = message["result"];
            if (result != null && result.Type == JTokenType.Null)
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

            var bRequest = (BinanceSocketRequest)request;
            var stream = message["stream"];
            if (stream == null)
                return false;

            return bRequest.Params.Contains(stream.ToString());
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier)
        {
            return true;
        }

        /// <inheritdoc />
        protected override Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection s)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscription)
        {
            var topics = ((BinanceSocketRequest)subscription.Request!).Params;
            var unsub = new BinanceSocketRequest { Method = "UNSUBSCRIBE", Params = topics, Id = NextId() };
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

                if ((int)id != unsub.Id)
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
