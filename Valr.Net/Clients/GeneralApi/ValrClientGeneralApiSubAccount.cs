using CryptoExchange.Net.Objects;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Objects.Models.General.SubAccount;

namespace Valr.Net.Clients.GeneralApi
{
    public class ValrClientGeneralApiSubAccount : IValrClientGeneralApiSubAccount
    {
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
