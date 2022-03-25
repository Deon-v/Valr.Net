using CryptoExchange.Net.Objects;
using Valr.Net.Objects.Models.General.Wallet;

namespace Valr.Net.Interfaces.Clients.GeneralApi.Wallets;

public interface IValrClientGeneralApiWalletFiat
{
    /// <summary>
    /// Get a list of bank accounts that are linked to your VALR account
    /// <para><a href="https://docs.valr.com/#e7b13f1d-9740-4452-9653-141e1055d03b" /></para>
    /// </summary>
    /// <param name="currencyCode">The currency code for which you want to query the Bank Accounts</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A collection of bank accounts</returns>
    Task<WebCallResult<IEnumerable<ValrBankAccountInfo>>> GetBankAccountsAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Get the unique Deposit Reference for the primary account or sub-account whose API Key is authorized
    /// <para><a href="https://docs.valr.com/#619d83fa-f562-4ed3-a573-81afbafd2f1c" /></para>
    /// </summary>
    /// <param name="currencyCode">The currency code for which you want to query the reference</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Deposit reference as a string</returns>
    Task<WebCallResult<ValrFiatDepositReference>> GetDepositReferenceAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Withdraw your fiat funds into one of your linked bank accounts
    /// <para><a href="https://docs.valr.com/#fb4db187-530b-4632-b933-7bdfd192bcf5" /></para>
    /// </summary>
    /// <param name="currencyCode">The currency code for which you want to query the whitelisted address</param>
    /// <param name="bankAccountId">The bank account id where the funds will be withdrawn to</param>
    /// <param name="amount">The amount to withdraw</param>
    /// <param name="fast">Should the withdrawal be processed with real-time clearing ("RTC")</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>An id associated with the withdrawal</returns>
    Task<WebCallResult<ValrWithdrawalId>> CreateWithdrawalAsync(string currencyCode, Guid bankAccountId, decimal amount, bool fast = false, long? receiveWindow = null, CancellationToken ct = default);
}