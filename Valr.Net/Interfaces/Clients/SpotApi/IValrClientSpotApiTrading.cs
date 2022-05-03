using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Objects.Models.Spot.Trading;

namespace Valr.Net.Interfaces.Clients.SpotApi
{
    public interface IValrClientSpotApiTrading
    {
        /// <summary>
        /// Create a new Market Order
        /// <para><a href="https://docs.valr.com/#e1892b20-2b2a-44cf-a67b-1d86def85ec4" /></para>
        /// </summary>
        /// <param name="symbol">The symbol the order is for</param>
        /// <param name="side">The order side (buy/sell)</param>
        /// <param name="quantity">The quantity of the symbol</param>
        /// <param name="newClientOrderId">Unique id for order</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>An order id</returns>
        Task<WebCallResult<ValrPlaceOrderResponse>> PlaceMarketOrderAsync(string symbol, ValrOrderSide side, decimal quantity, int? newClientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new Limit Order
        /// <para><a href="https://docs.valr.com/#5beb7328-24ca-4d8a-84f2-6029725ad923" /></para>
        /// </summary>
        /// <param name="symbol">The symbol the order is for</param>
        /// <param name="side">The order side (buy/sell)</param>
        /// <param name="quantity">The quantity of the symbol</param>
        /// <param name="price">The price of the order</param>
        /// <param name="postOnly">Ensures you remain a market maker on the exchange when true</param>
        /// <param name="timeInForce">Lifetime of the order, default GTC</param>
        /// <param name="clientOrderId">Unique id for order</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>An order id</returns>
        Task<WebCallResult<ValrPlaceOrderResponse>> PlaceLimitOrderAsync(string symbol, ValrOrderSide side, decimal quantity, decimal price, bool postOnly = false, ValrTimeInforce timeInForce = ValrTimeInforce.GTC, int? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new Stop Loss Limit or Take Profit Limit order
        /// <para><a href="https://docs.valr.com/#4bdd004a-a7a0-4d75-b018-d0e4b7316614" /></para>
        /// </summary>
        /// <param name="symbol">The symbol the order is for</param>
        /// <param name="side">The order side (buy/sell)</param>
        /// <param name="quantity">The quantity of the symbol</param>
        /// <param name="price">The price of the order</param>
        /// <param name="stopPrice">The target price for the trade to trigger. Cannot be equal to last traded price.</param>
        /// <param name="type">Can be TAKE_PROFIT_LIMIT or STOP_LOSS_LIMIT</param>
        /// <param name="timeInForce">Lifetime of the order, default GTC</param>
        /// <param name="newClientOrderId">Unique id for order</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>An order id</returns>
        Task<WebCallResult<ValrPlaceOrderResponse>> PlaceStopTakeLimitOrderAsync(string symbol, ValrOrderSide side, decimal quantity, decimal price, decimal stopPrice, ValrOrderType type, ValrTimeInforce timeInForce = ValrTimeInforce.GTC, int? newClientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Returns the status of an order that was placed on the Exchange
        /// <para><a href="https://docs.valr.com/#4bdd004a-a7a0-4d75-b018-d0e4b7316614" /></para>
        /// </summary>
        /// <param name="symbol">The symbol the order is for</param>
        /// <param name="id">The order id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>An order and its status</returns>
        Task<WebCallResult<ValrOrderStatusResponse>> GetOrderStatusAsync(string symbol, Guid id, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Returns the status of an order that was placed on the Exchange
        /// <para><a href="https://docs.valr.com/#87c78a99-c94c-4b16-a986-5957a62a66fc" /></para>
        /// </summary>
        /// <param name="symbol">The symbol the order is for</param>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>An order and its status</returns>
        Task<WebCallResult<ValrOrderStatusResponse>> GetOrderStatusAsync(string symbol, int clientOrderId, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get all open orders for your account
        /// <para><a href="https://docs.valr.com/#910bc498-b88d-48e8-b392-6cc94b8cb66d" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>A collection of open orders</returns>
        Task<WebCallResult<IEnumerable<ValrOpenOrderResponse>>> GetOpenOrderAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical orders placed by you
        /// <para><a href="https://docs.valr.com/#5f0ef16a-4f9d-40f3-bcdf-b1a63a0b42a4" /></para>
        /// </summary>
        /// <param name="skip">Number of items to skip from the list</param>
        /// <param name="limit">Limit the number of items returned</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>A collection of historical orders for the account</returns>
        Task<WebCallResult<IEnumerable<ValrOrderHistoryResponse>>> GetOrderHistoryAsync(int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a summary of a close("Filled", "Cancelled" or "Failed") order
        /// <para><a href="https://docs.valr.com/#7f42e4d5-c853-4da2-9c7d-adb4f3385ca2" /></para>
        /// </summary>
        /// <param name="id">Varl order id to get the summary for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>A single orders summary</returns>
        Task<WebCallResult<ValrOrderHistoryResponse>> GetOrderSummaryAsync(Guid id, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a summary of a close("Filled", "Cancelled" or "Failed") order
        /// <para><a href="https://docs.valr.com/#112c551e-4ee3-46a3-8fcf-0db07d3f48f2" /></para>
        /// </summary>
        /// <param name="clientOrderId">Your own order id to get the summary for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>A single orders summary</returns>
        Task<WebCallResult<ValrOrderHistoryResponse>> GetOrderSummaryAsync(int clientOrderId, long? receiveWindow = null, CancellationToken ct = default);


        /// <summary>
        /// Get a detailed history of an order's statuses
        /// <para><a href="https://docs.valr.com/#a5d5dbcd-e034-422c-acec-4257e3c12e2d" /></para>
        /// </summary>
        /// <param name="id">Varl order id to get the summary for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>A collection of order details</returns>
        Task<WebCallResult<IEnumerable<ValrOrderDetailResponse>>> GetOrderDetailAsync(Guid id, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a detailed history of an order's statuses
        /// <para><a href="https://docs.valr.com/#ed7fbcb1-550f-4b73-8b48-273f5ee78cdb" /></para>
        /// </summary>
        /// <param name="clientOrderId">Your own order id to get the summary for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>A collection of order details</returns>
        Task<WebCallResult<IEnumerable<ValrOrderDetailResponse>>> GetOrderDetailAsync(int clientOrderId, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open order
        /// <para><a href="https://docs.valr.com/#3d9ba169-7222-4c0f-ab08-87c22162c0c4" /></para>
        /// </summary>
        /// <param name="id">Varl order id</param>
        /// <param name="symbol">The symbol the order is for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Success or failure</returns>
        Task<WebCallResult> CancelOrderAsync(Guid id, string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open order
        /// <para><a href="https://docs.valr.com/#3d9ba169-7222-4c0f-ab08-87c22162c0c4" /></para>
        /// </summary>
        /// <param name="clientOrderId">Your own order id</param>
        /// <param name="symbol">The symbol the order is for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Success or failure</returns>
        Task<WebCallResult> CancelOrderAsync(int clientOrderId, string symbol, long? receiveWindow = null, CancellationToken ct = default);
    }
}
