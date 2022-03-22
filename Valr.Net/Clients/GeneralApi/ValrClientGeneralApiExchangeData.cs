using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Enpoints.GeneralApi;
using Valr.Net.Enums;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Objects.Models.General.ExchangeData;

namespace Valr.Net.Clients.GeneralApi
{
    public class ValrClientGeneralApiExchangeData : IValrClientGeneralApiExchangeData
    {
        private readonly Log _log;
        private readonly ValrClientGeneralApi _baseClient;

        internal ValrClientGeneralApiExchangeData(Log log, ValrClientGeneralApi valrClientGeneralApi)
        {
            _log = log;
            _baseClient = valrClientGeneralApi;
        }

        public async Task<WebCallResult<ValrOrderBook>> GetAuthenticatedOrderBookAggregatedAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<ValrOrderBook>(_baseClient.GetUrl(ExchangeDataEndpoints.OrderBookAuth.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        public async Task<WebCallResult<ValrOrderBook>> GetAuthenticatedOrderBookFullAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<ValrOrderBook>(_baseClient.GetUrl(ExchangeDataEndpoints.OrderBookFullAuth.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        public async Task<WebCallResult<IEnumerable<ValrMarketSummary>>> GetMarketSummariesAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<IEnumerable<ValrMarketSummary>>(_baseClient.GetUrl(ExchangeDataEndpoints.MarketSummary),
                HttpMethod.Get, ct).ConfigureAwait(false);
        }

        public async Task<WebCallResult<ValrMarketSummary>> GetMarketSummaryForPairAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<ValrMarketSummary>(_baseClient.GetUrl(ExchangeDataEndpoints.MarketSummaryForPair.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct).ConfigureAwait(false);
        }

        public async Task<WebCallResult<IEnumerable<ValrPairOrderTypes>>> GetOrderTypesByPairAsync(string? currencyPair = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestInternal<IEnumerable<ValrPairOrderTypes>>(_baseClient.GetUrl(ExchangeDataEndpoints.OrderTypes),
                HttpMethod.Get, ct).ConfigureAwait(false);

            if (currencyPair is not null && result.Success)
            {
                return result.As(result.Data.Where(x => x.CurrencyPair == currencyPair));
            }

            return result;
        }

        public async Task<WebCallResult<ValrOrderBook>> GetPublicOrderBookAggregatedAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<ValrOrderBook>(_baseClient.GetUrl(ExchangeDataEndpoints.OrderBook.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct).ConfigureAwait(false);
        }

        public async Task<WebCallResult<ValrOrderBook>> GetPublicOrderBookFullAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<ValrOrderBook>(_baseClient.GetUrl(ExchangeDataEndpoints.OrderBookFull.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct).ConfigureAwait(false);
        }

        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestInternal<ValrCheckTime>(_baseClient.GetUrl(ExchangeDataEndpoints.ServerTime), HttpMethod.Get, ct).ConfigureAwait(false);
            return result.As(result.Data?.time ?? default);
        }

        public async Task<WebCallResult<IEnumerable<ValrCurrency>>> GetSupportedCurrenciesAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<IEnumerable<ValrCurrency>>(_baseClient.GetUrl(ExchangeDataEndpoints.Currencies),
                HttpMethod.Get, ct).ConfigureAwait(false);
        }

        public async Task<WebCallResult<IEnumerable<ValrSymbol>>> GetSupportedPairsAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<IEnumerable<ValrSymbol>>(_baseClient.GetUrl(ExchangeDataEndpoints.CurrencyPairs),
                HttpMethod.Get, ct).ConfigureAwait(false);
        }

        public async Task<WebCallResult<ValrStatus>> GetSystemStatusAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestInternal<ValrSystemStatus>(_baseClient.GetUrl(ExchangeDataEndpoints.SystemStatus),
                HttpMethod.Get, ct).ConfigureAwait(false);

            return result.As(result.Data.status);
        }

        public async Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryAsync(string currencyPair, int skip = 0, int limit = 100, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("skip", skip);
            parameters.Add("limit", limit);

            return await _baseClient.SendRequestInternal<IEnumerable<ValrTrade>>(_baseClient.GetUrl(ExchangeDataEndpoints.TradeHistory.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct, parameters: parameters).ConfigureAwait(false);
        }

        public async Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryBeforeIdAsync(string currencyPair, Guid id, int limit = 100, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("limit", limit);
            parameters.Add("beforeId", id);

            return await _baseClient.SendRequestInternal<IEnumerable<ValrTrade>>(_baseClient.GetUrl(ExchangeDataEndpoints.TradeHistory.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct, parameters: parameters).ConfigureAwait(false);
        }

        public async Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryFilteredAsync(string currencyPair, DateTime startTime, DateTime endTime, int skip = 0, int limit = 100, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("skip", skip);
            parameters.Add("limit", limit);
            parameters.Add("startTime", startTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            parameters.Add("endTime", endTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

            return await _baseClient.SendRequestInternal<IEnumerable<ValrTrade>>(_baseClient.GetUrl(ExchangeDataEndpoints.TradeHistory.Replace(":currencyPair", currencyPair)),
                HttpMethod.Get, ct, parameters: parameters, postPosition :HttpMethodParameterPosition.InUri).ConfigureAwait(false);
        }
    }
}
