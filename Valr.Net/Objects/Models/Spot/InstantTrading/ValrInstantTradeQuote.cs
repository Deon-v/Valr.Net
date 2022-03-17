using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.InstantTrading
{
    public class ValrInstantTradeQuote
    {
        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("payAmount")]
        public decimal PayAmount { get; set; }

        [JsonProperty("receiveAmount")]
        public decimal ReceiveAmount { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
