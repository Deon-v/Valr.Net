using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
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

        public Task<WebCallResult<ValrOrderBook>> GetAuthenticatedOrderBookAggregatedAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrOrderBook>> GetAuthenticatedOrderBookFullAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrMarketSummary>>> GetMarketSummariesAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrMarketSummary>> GetMarketSummaryForPairAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrPairOrderTypes>>> GetOrderTypesByPairAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrOrderBook>> GetPublicOrderBookAggregatedAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrOrderBook>> GetPublicOrderBookFullAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrCurrency>>> GetSupportedCurrenciesAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrSymbol>>> GetSupportedPairsAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrStatus>> GetSystemStatusAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryAsync(string currencyPair, int skip = 0, int limit = 100, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryBeforeIdAsync(string currencyPair, Guid id, int limit = 100, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryFilteredAsync(string currencyPair, DateTime startTime, DateTime endTime, int skip = 0, int limit = 100, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
