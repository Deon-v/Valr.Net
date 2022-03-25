using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Valr.Net.Interfaces.Clients.SpotApi;
using Valr.Net.Objects.Options;

namespace Valr.Net.Clients.SpotApi
{
    public class ValrClientSpotApi : RestApiClient, IValrClientSpotApi
    {
        #region fields 
        private readonly ValrClient _baseClient;
        internal new readonly ValrClientOptions Options;

        internal DateTime? LastExchangeInfoUpdate;

        internal static TimeSyncState TimeSyncState = new TimeSyncState("Spot Api");

        private readonly Log _log;
        #endregion

        #region Api clients
        /// <inheritdoc />
        public IValrClientSpotApiTrading Spot { get; }
        /// <inheritdoc />
        public IValrClientSpotApiInstantTrading InstantTrade { get; }
        #endregion

        /// <summary>
        /// Event triggered when an order is placed via this client. Only available for Spot orders
        /// </summary>
        public event Action<OrderId>? OnOrderPlaced;
        /// <summary>
        /// Event triggered when an order is canceled via this client. Note that this does not trigger when using CancelAllOrdersAsync. Only available for Spot orders
        /// </summary>
        public event Action<OrderId>? OnOrderCanceled;

        public ValrClientSpotApi(Log log, ValrClient baseClient, ValrClientOptions options) : base(options, options.SpotApiOptions)
        {
            _log = log;
            _baseClient = baseClient;
            Options = options;

            Spot = new ValrClientSpotApiTrading(log, this);
            InstantTrade = new ValrClientSpotApiInstantTrading(log, this);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new ValrAuthenticationProvider(credentials);

        #region helpers
        internal Uri GetUrl(string endpoint)
        {
            return new Uri(BaseAddress.AppendPath(endpoint));
        }

        internal async Task<WebCallResult<T>> SendRequestInternal<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken,
            Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? postPosition = null,
            ArrayParametersSerialization? arraySerialization = null, int weight = 1, bool ignoreRateLimit = false) where T : class
        {
            var result = await _baseClient.SendRequestInternal<T>(this, uri, method, cancellationToken, parameters, signed, postPosition, arraySerialization, weight, ignoreRateLimit: ignoreRateLimit).ConfigureAwait(false);
            if (!result && result.Error!.Code == -1021 && Options.SpotApiOptions.AutoTimestamp)
            {
                _log.Write(LogLevel.Debug, "Received Invalid Timestamp error, triggering new time sync");
                TimeSyncState.LastSyncTime = DateTime.MinValue;
            }
            return result;
        }

        #endregion

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => _baseClient.GeneralApi.ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        protected override TimeSyncInfo GetTimeSyncInfo()
            => new TimeSyncInfo(_log, Options.SpotApiOptions.AutoTimestamp, Options.SpotApiOptions.TimestampRecalculationInterval, TimeSyncState);

        /// <inheritdoc />
        public override TimeSpan GetTimeOffset()
            => TimeSyncState.TimeOffset;

        /// <inheritdoc />
        public string GetSymbolName(string baseAsset, string quoteAsset) =>
            (baseAsset + quoteAsset).ToUpper(CultureInfo.InvariantCulture);

        internal void InvokeOrderPlaced(OrderId id)
        {
            OnOrderPlaced?.Invoke(id);
        }

        internal void InvokeOrderCanceled(OrderId id)
        {
            OnOrderCanceled?.Invoke(id);
        }
    }
}
