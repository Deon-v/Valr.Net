using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.ExchangeData
{
    public class ValrTrade
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("tradedAt")]
        public DateTime TradeTime { get; set; }

        [JsonProperty("side")]
        public OrderSide Side { get; set; }

        [JsonProperty("takerSide")]
        private OrderSide TakerSide
        {
            set
            {
                Side = value;
            }
        }

        [JsonProperty("sequenceId")]
        public int SequenceId { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonProperty("quoteVolume")]
        public decimal? QuoteVolume { get; set; }
    }

    public class TradeWrapper
    {
        public ValrTrade[] Trades { get; set; }
    }

}
