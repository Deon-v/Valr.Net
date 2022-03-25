using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Objects.Models.Spot.InstantTrading;

namespace Valr.Net.Interfaces.Clients.SpotApi;

public interface IValrClientSpotApiInstantTrading
{
    /// <summary>
    /// Get a quote to buy or sell instantly using Simple Buy
    /// <para><a href="https://docs.valr.com/#8c1df98d-5878-44f0-9090-2211f793fd6f" /></para>
    /// </summary>
    /// <param name="currencyPair">Currency pair to get a simple quote for</param>
    /// <param name="symbol">The currency pair the order is for</param>
    /// <param name="side">The order side (buy/sell)</param>
    /// <param name="quantity">The quantity of the payInCurrency</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A quote for the provided values</returns>
    Task<WebCallResult<ValrInstantTradeQuote>> GetQuoteAsync(string currencyPair, string symbol, ValrOrderSide side, decimal quantity, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Submit an order to buy or sell instantly using Simple Buy/Sell
    /// <para><a href="https://docs.valr.com/#b064c7f3-d789-47ea-a427-e86a8039fdda" /></para>
    /// </summary>
    /// <param name="currencyPair">Currency pair to place a simple order for</param>
    /// <param name="symbol">The currency the order is for</param>
    /// <param name="side">The order side (buy/sell)</param>
    /// <param name="quantity">The quantity of the payInCurrency</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Success or failure</returns>
    Task<WebCallResult<ValrInstantTradeResponse>> PlaceInstantOrderAsync(string currencyPair, string symbol, ValrOrderSide side, decimal quantity, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Submit an order to buy or sell instantly using Simple Buy/Sell
    /// <para><a href="https://docs.valr.com/#c001557e-0356-4b5f-92cf-64d3b2fe98ed" /></para>
    /// </summary>
    /// <param name="currencyPair">The currency pair the order is for</param>
    /// <param name="id">Id of the instant order</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>An instant trade with its status</returns>
    Task<WebCallResult<ValrInstantTradeStatusResponse>> GetInstantOrderStatusAsync(string currencyPair, Guid id, long? receiveWindow = null, CancellationToken ct = default);
}