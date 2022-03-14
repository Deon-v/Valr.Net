using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Objects.Models.Spot.Account;
using Valr.Net.Objects.Models.Spot.ExchangeData;

namespace Valr.Net.Interfaces.Clients.SpotApi
{
    public interface IValrClientSpotApiAccount
    {
        /// <summary>
        /// Gets account balances
        /// <para><a href="https://docs.valr.com/#60455ec7-ecdc-42ad-9a57-64941299da52" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrAccountBalance>>> GetAccountBalancesAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the transaction history for the account
        /// <para><a href="https://docs.valr.com/#a84bf578-adb8-4023-8aa0-5f74550490a8" /></para>
        /// </summary>
        /// <param name="skip">Number of items to skip from the list</param>
        /// <param name="limit">Limit the number of items returned. Max: 200</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrAccountTransaction>>> GetAccountHistoryAsync(int skip = 0, int limit = 200, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the transaction history for the account using filters
        /// <para><a href="https://docs.valr.com/#0d7cc0ff-b8ca-4e1f-980e-36d07672e53d" /></para>
        /// </summary>
        /// <param name="transactionTypes">Array of transaction types to include in filter</param>
        /// <param name="startTime">Include only transactions after this ISO 8601 start time</param>
        /// <param name="endTime">Include only transactions before this ISO 8601 end time</param>
        /// <param name="currency">Include only transactions in this currency</param>
        /// <param name="skip">Number of items to skip from the list</param>
        /// <param name="limit">Limit the number of items returned. Max: 200</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrAccountTransaction>>> GetAccountHistoryFilteredAsync(ValrTransactionType[] transactionTypes, DateTime startTime, DateTime endTime, string? currency = null, int skip = 0, int limit = 200, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the transaction that occurred before the given transaction Id
        /// <para><a href="https://docs.valr.com/#c2f6db65-1fe4-4561-9e5e-d28d6a4fca9d" /></para>
        /// </summary>
        /// <param name="Id">Only include transactions before this ID</param>
        /// <param name="limit">Limit the number of items returned. Max: 200</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrAccountTransaction>>> GetAccountHistoryBeforeIdAsync(Guid Id, int limit = 200, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get the max 100 recent trades for a given currency pair for your account
        /// <para><a href="https://docs.valr.com/#11856958-9461-490e-9e01-4b1f5a2097ae" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to query the trade history</param>
        /// <param name="limit">Limit the number of items returned. Max: 100</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrTrade>>> GetRecentTradesByPairAsync(string currencyPair, int limit = 100, long? receiveWindow = null, CancellationToken ct = default);
    }
}
