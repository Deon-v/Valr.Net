using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class OpenOrderData
    {
        [JsonProperty("orderId")]
        public Guid orderId { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValrOrderSide Side { get; set; }

        [JsonProperty("remainingQuantity")]
        public decimal RemainingQuantity { get; set; }

        [JsonProperty("originalPrice")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("currencyPair")]
        public Currencypair CurrencyPair { get; set; }

        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }

        [JsonProperty("originalQuantity")]
        public decimal OriginalQuantity { get; set; }

        [JsonProperty("filledPercentage")]
        public decimal FilledPercentage { get; set; }

        [JsonProperty("customerOrderId")]
        public string CustomerOrderId { get; set; }
    }

    public class Currencypair
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("baseCurrency")]
        public CurrencyInfo BaseCurrency { get; set; }

        [JsonProperty("quoteCurrency")]
        public CurrencyInfo QuoteCurrency { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

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

    }

    public class CurrencyInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("decimalPlaces")]
        public int DecimalPlaces { get; set; }

        [JsonProperty("isActive")]
        public bool Active { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }

        [JsonProperty("currencyDecimalPlaces")]
        public int CurrencyDecimalPlaces { get; set; }

        [JsonProperty("supportedWithdrawDecimalPlaces")]
        public int SupportedWithdrawDecimalPlaces { get; set; }
    }
}
