namespace Valr.Net.Endpoints.GeneralApi
{
    internal static class ExchangeDataEndpoints
    {
        internal const string ServerTime = "v1/public/time";
        internal const string OrderBook = "v1/public/:currencyPair/orderbook";
        internal const string OrderBookFull = "v1/public/:currencyPair/orderbook/full";
        internal const string OrderBookAuth = "v1/marketdata/:currencyPair/orderbook";
        internal const string OrderBookFullAuth = "v1/marketdata/:currencyPair/orderbook/full";
        internal const string Currencies = "v1/public/currencies";
        internal const string CurrencyPairs = "v1/public/pairs";
        internal const string OrderTypes = "v1/public/ordertypes";
        internal const string MarketSummary = "v1/public/marketsummary";
        internal const string MarketSummaryForPair = "v1/public/marketsummary";
        internal const string TradeHistory = "v1/public/:currencyPair/trades";
        internal const string SystemStatus = "v1/public/status";
    }
}
