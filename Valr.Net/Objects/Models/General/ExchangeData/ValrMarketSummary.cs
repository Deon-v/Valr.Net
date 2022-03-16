using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.ExchangeData
{
    public class ValrMarketSummary
    {
        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("askPrice")]
        public decimal AskPrice { get; set; }

        [JsonProperty("bidPrice")]
        public decimal BidPrice { get; set; }

        [JsonProperty("lastTradedPrice")]
        public decimal LastTradedPrice { get; set; }

        [JsonProperty("previousClosePrice")]
        public decimal PreviousClosePrice { get; set; }

        [JsonProperty("baseVolume")]
        public decimal BaseVolume { get; set; }

        [JsonProperty("highPrice")]
        public decimal HighPrice { get; set; }

        [JsonProperty("lowPrice")]
        public decimal LowPrice { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("changeFromPrevious")]
        public decimal ChangeFromPrevious { get; set; }
    }

    public class MarketSummaryWrapper
    {
        public ValrMarketSummary[] MarketSummaries { get; set; }
    }
}
