namespace Valr.Net.Endpoints.SpotApi
{
    internal static class TradingEndpoints
    {
        internal const string LimitOrder = "v1/orders/limit";
        internal const string MarketOrder = "v1/orders/market";
        internal const string StopLimitOrder = "v1/orders/stop/limit";
        internal const string OrderStatusId = "v1/orders/:currencyPair/orderid/:orderId";
        internal const string OrderStatusCustomId = "v1/orders/:currencyPair/customerorderid/:customerOrderId";
        internal const string OpenOrders = "v1/orders/open";
        internal const string OrderHistory = "v1/orders/history";
        internal const string OrderHistorySummaryId = "v1/orders/history/summary/orderid/:orderId";
        internal const string OrderHistorySummaryCustomId = "v1/orders/history/summary/customerorderid/:customerOrderId";
        internal const string OrderHistoryDetailId = "v1/orders/history/detail/orderid/:orderId";
        internal const string OrderHistoryDetailCustomId = "v1/orders/history/detail/customerorderid/:customerOrderId";
        internal const string DeleteOrder = "v1/orders/order";
    }
}
