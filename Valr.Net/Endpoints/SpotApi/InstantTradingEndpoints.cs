namespace Valr.Net.Endpoints.SpotApi
{
    internal static class InstantTradingEndpoints
    {
        internal const string Quote = "v1/simple/:currencyPair/quote";
        internal const string PlaceOrder = "v1/simple/:currencyPair/order";
        internal const string OrderStatus = "v1/simple/:currencyPair/order/:orderId";
    }
}
