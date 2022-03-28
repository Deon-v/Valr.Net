using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.ExchangeData
{
    public class ValrOrderBook
    {
        public string Symbol { get; set; }
        public ValrOrderBookSymbol[] Asks { get; set; }
        public ValrOrderBookSymbol[] Bids { get; set; }
        public DateTime LastChange { get; set; }
        public int SequenceNumber { get; set; }
    }

    public class ValrOrderBookSymbol
    {
        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        /// <summary>
        /// Only used for aggregated order books to indicate how many orders are aggregated together
        /// </summary>
        [JsonProperty("orderCount")]
        public int? OrderCount { get; set; }

        /// <summary>
        /// Only used for full order books
        /// </summary>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Only used for full order books
        /// </summary>
        [JsonProperty("positionAtPrice")]
        public int? PositionAtPrice { get; set; }
    }
}
