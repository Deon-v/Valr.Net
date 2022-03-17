using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Objects.Models.General.Account;
using Valr.Net.Objects.Models.General.ExchangeData;

namespace Valr.Net.Clients.GeneralApi
{
    public class ValrClientGeneralApiAccount : IValrClientGeneralApiAccount
    {
        private readonly Log _log;
        private readonly ValrClientGeneralApi _baseClient;

        internal ValrClientGeneralApiAccount(Log log, ValrClientGeneralApi valrClientGeneralApi)
        {
            _log = log;
            _baseClient = valrClientGeneralApi;
        }

        public Task<WebCallResult<IEnumerable<ValrAccountBalance>>> GetAccountBalancesAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrAccountTransaction>>> GetAccountHistoryAsync(int skip = 0, int limit = 200, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrAccountTransaction>>> GetAccountHistoryBeforeIdAsync(Guid Id, int limit = 200, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrAccountTransaction>>> GetAccountHistoryFilteredAsync(ValrTransactionType[] transactionTypes, DateTime startTime, DateTime endTime, string? currency = null, int skip = 0, int limit = 200, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrTrade>>> GetRecentTradesByPairAsync(string currencyPair, int limit = 100, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
