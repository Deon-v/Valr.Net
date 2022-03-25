using CryptoExchange.Net.Objects;
using Valr.Net.Objects.Models.General.Wallet;

namespace Valr.Net.Interfaces.Clients.GeneralApi.Wallets;

public interface IValrClientGeneralApiWalletWire
{
    /// <summary>
    /// Get a list of all authorized wire bank accounts that are linked to your VALR account
    /// <para><a href="https://docs.valr.com/#1e9495b9-e3ae-461f-9340-5e22cded4eba" /></para>
    /// </summary>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A collection of wire bank accounts</returns>
    Task<WebCallResult<IEnumerable<ValrWireAccountInfo>>> GetWireAccountsAsync(long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Fetches the deposit (wire) instructions for the account specified by the identifier
    /// <para><a href="https://docs.valr.com/#2e8704d9-5422-4834-b226-23f93515cbe6" /></para>
    /// </summary>
    /// <param name="wireAccountId">The wire account id where that you want to query</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A valid response will contain all the details needed to make a wire payment to this account</returns>
    Task<WebCallResult<ValrWireDepositInstructions>> GetWireDepositInstructionsAsync(Guid wireAccountId, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Withdraw your USDC funds into one of your linked wire accounts in USD
    /// <para><a href="https://docs.valr.com/#2f730f04-ade8-4394-b97f-a359ebcae745" /></para>
    /// </summary>
    /// <param name="wireAccountId">The wire account id where the funds will be withdrawn to</param>
    /// <param name="amount">The amount to withdraw in USD</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>An id associated with the withdrawal</returns>
    Task<WebCallResult<ValrWireTransferResponse>> CreateWithdrawalAsync(Guid wireAccountId, decimal amount, long? receiveWindow = null, CancellationToken ct = default);
}