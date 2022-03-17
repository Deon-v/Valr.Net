using CryptoExchange.Net.Objects;
using Valr.Net.Objects.Models.General.SubAccount;

namespace Valr.Net.Interfaces.Clients.GeneralApi
{
    public interface IValrClientGeneralApiSubAccount
    {
        /// <summary>
        /// Gets a list of sub accounts associated with this master account
        /// <para><a href="https://docs.valr.com/#9443d7ce-c1c5-4597-b43e-d8fc2e7b49a7" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of sub accounts</returns>
        Task<WebCallResult<IEnumerable<ValrSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets list of balances grouped by sub account
        /// <para><a href="https://docs.valr.com/#f690f824-c254-4d85-8013-27e317addf67" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of balances</returns>
        Task<WebCallResult<ValrSubAccountBalances>> GetSubAccountBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// Create a new sub account
        /// <para><a href="https://docs.valr.com/#ee3e19d6-a530-441d-aaf6-a526d368ff82" /></para>
        /// </summary>
        /// <param name="label">The label the sub account will be given. Should not contain special characters</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The label for the sub account</returns>
        Task<WebCallResult<ValrSubAccountCreated>> CreateSubAccountAsync(string label, CancellationToken ct = default);

        /// <summary>
        /// Transfer funds between two accounts
        /// <para><a href="https://docs.valr.com/#f065f4d0-bde5-4793-874d-3b2c67f5e42d" /></para>
        /// </summary>
        /// <param name="asset">The asset</param>
        /// <param name="fromId">The id of the source account. Use 0 for the primary account</param>
        /// <param name="toId">The id of destination account. Use 0 for the primary account</param>
        /// <param name="amount">The total amount being transferred</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Transfer history</returns>
        Task<WebCallResult<bool>> GetSubAccountTransferHistoryForSubAccountAsync(string? asset, string fromId, string toId, decimal amount, int? receiveWindow = null, CancellationToken ct = default);
    }
}
