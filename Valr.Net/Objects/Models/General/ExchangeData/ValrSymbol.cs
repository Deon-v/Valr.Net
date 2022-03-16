using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.ExchangeData
{
    public class ValrSymbol
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("minBaseAmount")]
        public decimal MinBaseAmount { get; set; }

        [JsonProperty("maxBaseAmount")]
        public decimal MaxBaseAmount { get; set; }

        [JsonProperty("minQuoteAmount")]
        public decimal MinQuoteAmount { get; set; }

        [JsonProperty("maxQuoteAmount")]
        public decimal MaxQuoteAmount { get; set; }

        [JsonProperty("tickSize")]
        public decimal TickSize { get; set; }

        [JsonProperty("baseDecimalPlaces")]
        public decimal BaseDecimalPlaces { get; set; }
    }
}
