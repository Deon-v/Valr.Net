using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Valr.Net.Clients.SpotApi;
using Valr.Net.Interfaces.Clients.PayApi;
using Valr.Net.Objects.Options;

namespace Valr.Net.Clients.PayApi
{
    public class ValrClientPayApi : RestApiClient, IValrClientPayApi
    {
        #region fields
        private readonly Log _log;
        private readonly ValrClient _baseClient;
        internal new readonly ValrClientOptions Options;
        #endregion

        #region Api clients
        /// <inheritdoc />
        public IValrClientPayApiValrPay VarlPay { get; }
        #endregion

        #region constructor/destructor
        public ValrClientPayApi(Log log, ValrClient baseClient, ValrClientOptions options) : base(options, options.PayApiOptions)
        {
            Options = options;
            _baseClient = baseClient;
            _log = log;

            VarlPay = new ValrClientPayApiValrPay(log, this);
        }
        #endregion

        internal Uri GetUrl(string endpoint, string api, string? version = null)
        {
            var result = BaseAddress.AppendPath(api);

            if (!string.IsNullOrEmpty(version))
                result = result.AppendPath($"v{version}");

            return new Uri(result.AppendPath(endpoint));
        }

        internal async Task<WebCallResult<T>> SendRequestInternal<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken,
            Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? postPosition = null,
            ArrayParametersSerialization? arraySerialization = null, int weight = 1, bool ignoreRateLimit = false) where T : class
        {
            var result = await _baseClient.SendRequestInternal<T>(this, uri, method, cancellationToken, parameters, signed, postPosition, arraySerialization, weight, ignoreRateLimit: ignoreRateLimit).ConfigureAwait(false);
            if (!result && result.Error!.Code == -1021 && Options.SpotApiOptions.AutoTimestamp)
            {
                _log.Write(LogLevel.Debug, "Received Invalid Timestamp error, triggering new time sync");
                ValrClientSpotApi.TimeSyncState.LastSyncTime = DateTime.MinValue;
            }
            return result;
        }

        protected override TimeSyncInfo GetTimeSyncInfo() =>
            new TimeSyncInfo(_log, Options.SpotApiOptions.AutoTimestamp, Options.SpotApiOptions.TimestampRecalculationInterval, ValrClientSpotApi.TimeSyncState);

        public override TimeSpan GetTimeOffset() => ValrClientSpotApi.TimeSyncState.TimeOffset;

        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync() =>
            _baseClient.GeneralApi.ExchangeData.GetServerTimeAsync();

        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new ValrAuthenticationProvider(credentials);
    }
}
