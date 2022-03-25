using CryptoExchange.Net.Objects;
using Valr.Net.Objects.Models.General.Wallet;

namespace Valr.Net.Interfaces.Clients.GeneralApi.Wallets;

public interface IValrClientGeneralApiWalletCrypto
{
    /// <summary>
    /// Returns the default deposit address associated with currency specified
    /// <para><a href="https://docs.valr.com/#b10ea5dd-00cb-4c33-bb28-53104a8f1b7b" /></para>
    /// </summary>
    /// <param name="currencyCode">The currency code for which you want to query the deposit address</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>An address that can receive deposits</returns>
    Task<WebCallResult<IEnumerable<ValrWalletAddress>>> GetDepositAddressAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Returns all the withdrawal addresses whitelisted for this account
    /// <para><a href="https://docs.valr.com/#b54b42e0-d721-4cc7-b6c2-59cb05b39568" /></para>
    /// </summary>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A collection of address that can be withdrawn to</returns>
    Task<WebCallResult<IEnumerable<ValrWhitelistedAddress>>> GetWhitelistedWithdrawalAddressAsync(long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Returns all the withdrawal addresses whitelisted for this account and the currency specified
    /// <para><a href="https://docs.valr.com/#f4c4548b-67b0-4f55-80c0-62b605926c6d" /></para>
    /// </summary>
    /// <param name="currencyCode">The currency code for which you want to query the whitelisted address</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A collection of address that can be withdrawn to</returns>
    Task<WebCallResult<IEnumerable<ValrWhitelistedAddress>>> GetWhitelistedWithdrawalAddressAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Get all the information about withdrawing the given currency from your VALR account
    /// <para><a href="https://docs.valr.com/#f4c4548b-67b0-4f55-80c0-62b605926c6d" /></para>
    /// </summary>
    /// <param name="currencyCode">This is the currency code of the currency you want  withdrawal information about</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>The information and costs to withdraw a currency</returns>
    Task<WebCallResult<ValrWithdrawalInfo>> GetWithdrawalInfoAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Withdraw crypto currency funds to an address
    /// <para><a href="https://docs.valr.com/#bb0ad4dc-a28d-41a3-8e59-5070bc589c5a" /></para>
    /// </summary>
    /// <param name="currencyCode">This is the currency code for the currency you are withdrawing</param>
    /// <param name="paymentReference">Only applicable for withdrawals that require a destination tag or equivalent</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>An id associated with the withdrawal</returns>
    Task<WebCallResult<ValrWithdrawalId>> DoWithdrawalAsync(string currencyCode, decimal amount, string address, string? paymentReference = null, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Check the status of a withdrawal
    /// <para><a href="https://docs.valr.com/#b1f5aae3-c896-4a7f-a20a-ff4d67ea8007" /></para>
    /// </summary>
    /// <param name="currencyCode">This is the currency code for the currency you are quesrying the status</param>
    /// <param name="Id">The unique id that represents your withdrawal request</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>The status of the withdrawal</returns>
    Task<WebCallResult<ValrWithdrawalStatusInfo>> GetWithdrawalStatusAsync(string currencyCode, Guid Id, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Get Withdrawal History records for a given currency
    /// <para><a href="https://docs.valr.com/#d166dbf5-e922-4037-b0a7-5d490796662c" /></para>
    /// </summary>
    /// <param name="currencyCode">This is the currency code for the currency you are quesrying the status</param>
    /// <param name="skip">Number of items to skip from the list</param>
    /// <param name="limit">Limit the number of items returned.</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A collection of withdrawals</returns>
    Task<WebCallResult<IEnumerable<ValrWithdrawalStatusInfo>>> GetWithdrawalHistoryAsync(string currencyCode, int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Get the Deposit History records for a given currency
    /// <para><a href="https://docs.valr.com/#1061d8de-3792-4a0a-8ae6-715cb8a5179e" /></para>
    /// </summary>
    /// <param name="currencyCode">This is the currency code for the currency you are quesrying the status</param>
    /// <param name="skip">Number of items to skip from the list</param>
    /// <param name="limit">Limit the number of items returned.</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A collection of deposits</returns>
    Task<WebCallResult<IEnumerable<ValrDepositStatusInfo>>> GetDepositHistoryAsync(string currencyCode, int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default);

}