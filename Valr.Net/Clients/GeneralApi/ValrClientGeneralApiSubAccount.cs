using CryptoExchange.Net;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Endpoints.GeneralApi;
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

        public async Task<WebCallResult<ValrSubAccountCreated>> CreateSubAccountAsync(string label, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddParameter("label", label);

            return await _baseClient.SendRequestInternal<ValrSubAccountCreated>(_baseClient.GetUrl(SubAccountEndpoints.Register),
                HttpMethod.Get, ct, parameters: parameters, signed: true).ConfigureAwait(false);
        }

        public async Task<WebCallResult<ValrSubAccountBalances>> GetSubAccountBalancesAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<ValrSubAccountBalances>(_baseClient.GetUrl(SubAccountEndpoints.Balances),
                HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        public async Task<WebCallResult<IEnumerable<ValrSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestInternal<IEnumerable<ValrSubAccount>>(_baseClient.GetUrl(SubAccountEndpoints.SubAccounts),
                HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        public async Task<WebCallResult<bool>> CreateSubAccountTransferAsync(string asset, string fromId, string toId, decimal amount, int? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddParameter("fromId", fromId);
            parameters.AddParameter("toId", toId);
            parameters.AddParameter("amount", amount);
            parameters.AddParameter("currencyCode", asset);

            var result = await _baseClient.SendRequestInternal<object>(_baseClient.GetUrl(SubAccountEndpoints.Transfer),
                HttpMethod.Post, ct, parameters: parameters, signed: true).ConfigureAwait(false);

            return result.As(result.Success);
        }
    }
}
