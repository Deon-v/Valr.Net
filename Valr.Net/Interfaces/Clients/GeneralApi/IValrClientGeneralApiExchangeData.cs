using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Objects.Models.General.ExchangeData;

namespace Valr.Net.Interfaces.Clients.GeneralApi
{
    public interface IValrClientGeneralApiExchangeData
    {
        /// <summary>
        /// Gets the status of the Valr Exchange
        /// <para><a href="https://docs.valr.com/#16ccc087-4f8c-49b0-aa43-fd4f472c6a52" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The system status</returns>
        Task<WebCallResult<ValrStatus>> GetSystemStatusAsync(CancellationToken ct = default);

        /// <summary>
        /// Requests the server for the local time
        /// <para><a href="https://docs.valr.com/#95f84056-2ac7-4f92-a5d9-fd0d9c104f01" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Server time</returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the trade history for the given currency pair
        /// <para><a href="https://docs.valr.com/#68ecbf66-c8ab-4460-a1f3-5b245b15877e" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to query the trade history</param>
        /// <param name="skip">Number of items to skip from the list</param>
        /// <param name="limit">Limit the number of items returned. Max: 100</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryAsync(string currencyPair, int skip = 0, int limit = 100, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the trade history for the given currency pair using filters
        /// <para><a href="https://docs.valr.com/#f34f0b86-3f74-456f-b72c-93baa57ad20c" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to query the trade history</param>
        /// <param name="startTime">Include only transactions after this ISO 8601 start time</param>
        /// <param name="endTime">Include only transactions before this ISO 8601 end time</param>
        /// <param name="skip">Number of items to skip from the list</param>
        /// <param name="limit">Limit the number of items returned. Max: 100</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryFilteredAsync(string currencyPair, DateTime startTime, DateTime endTime, int skip = 0, int limit = 100, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the trade history that occurred before the given transaction id for the given currency pair
        /// <para><a href="https://docs.valr.com/#c2f6db65-1fe4-4561-9e5e-d28d6a4fca9d" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to query the trade history</param>
        /// <param name="id">Only include transactions before this ID</param>
        /// <param name="limit">Limit the number of items returned. Max: 100</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrTrade>>> GetTradeHistoryBeforeIdAsync(string currencyPair, Guid id, int limit = 100, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get the market summary for all supported currency pairs
        /// <para><a href="https://docs.valr.com/#cd1f0448-3da3-44cf-b00d-91edd74e7e19" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrMarketSummary>>> GetMarketSummariesAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get the market summary for a given currency pair
        /// <para><a href="https://docs.valr.com/#89b446bb-60a6-42ff-aa09-29e4918a9eb0" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to query the market summary</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<ValrMarketSummary>> GetMarketSummaryForPairAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get all the order types supported for all currency pairs
        /// <para><a href="https://docs.valr.com/#700eddaa-60ba-4872-ae2b-577c3285d695" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to query the allowed order types</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrPairOrderTypes>>> GetOrderTypesByPairAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of currencies supported by VALR
        /// <para><a href="https://docs.valr.com/#88ab52a2-d63b-48b2-8984-d0982baec40a" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrCurrency>>> GetSupportedCurrenciesAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of all the currency pairs supported by VALR
        /// <para><a href="https://docs.valr.com/#cfa57d7e-2106-4066-bc27-c10210b6aa82" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<IEnumerable<ValrSymbol>>> GetSupportedPairsAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get aggregated order book of the top 40 bids and asks for the symbol pair
        /// <para><a href="https://docs.valr.com/#720fec1b-a1f6-486a-b04a-7ae76c6f9f66" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to order book</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<ValrOrderBook>> GetPublicOrderBookAggregatedAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get full order book for the symbol pair
        /// <para><a href="https://docs.valr.com/#9ee254bd-4361-40e8-95a1-f57e74968f24" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to order book</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<ValrOrderBook>> GetPublicOrderBookFullAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get aggregated order book of the top 40 bids and asks for the symbol pair, requires authentication and uses more constrained rate-limiting rules 
        /// <para><a href="https://docs.valr.com/#926f9245-35d1-4bca-a114-0af07bc229f7" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to order book</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<ValrOrderBook>> GetAuthenticatedOrderBookAggregatedAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get full order book for the symbol pair, requires authentication and uses more constrained rate-limiting rules
        /// <para><a href="https://docs.valr.com/#c2acf6b9-dbba-4e6a-9075-a7907360812d" /></para>
        /// </summary>
        /// <param name="currencyPair">The currency pair for which you want to order book</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<ValrOrderBook>> GetAuthenticatedOrderBookFullAsync(string currencyPair, long? receiveWindow = null, CancellationToken ct = default);
    }
}
