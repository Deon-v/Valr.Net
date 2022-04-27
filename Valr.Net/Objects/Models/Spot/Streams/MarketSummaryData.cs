using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.Streams
{
    public class MarketSummaryData
    {
        [JsonProperty("currencyPairSymbol")]
        public string Symbol { get; set; }

        [JsonProperty("askPrice")]
        public decimal Ask { get; set; }

        [JsonProperty("bidPrice")]
        public decimal Bid { get; set; }

        [JsonProperty("lastTradedPrice")]
        public decimal LastTraded { get; set; }

        [JsonProperty("previousClosePrice")]
        public decimal PreviousClose { get; set; }

        [JsonProperty("baseVolume")]
        public decimal BaseVolume { get; set; }

        [JsonProperty("highPrice")]
        public decimal High { get; set; }

        [JsonProperty("lowPrice")]
        public decimal Low { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("changeFromPrevious")]
        public decimal Change { get; set; }
    }
}
