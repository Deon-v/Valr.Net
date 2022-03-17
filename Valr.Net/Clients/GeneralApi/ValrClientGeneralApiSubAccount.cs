using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Objects.Models.General.SubAccount;

namespace Valr.Net.Clients.GeneralApi
{
    public class ValrClientGeneralApiSubAccount : IValrClientGeneralApiSubAccount
    {
        private readonly Log _log;
        private readonly ValrClientGeneralApi _baseClient;

        internal ValrClientGeneralApiSubAccount(Log log, ValrClientGeneralApi valrClientGeneralApi)
        {
            _log = log;
            _baseClient = valrClientGeneralApi;
        }

        public Task<WebCallResult<ValrSubAccountCreated>> CreateSubAccountAsync(string label, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrSubAccountBalances>> GetSubAccountBalancesAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<IEnumerable<ValrSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<bool>> GetSubAccountTransferHistoryForSubAccountAsync(string? asset, string fromId, string toId, decimal amount, int? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
