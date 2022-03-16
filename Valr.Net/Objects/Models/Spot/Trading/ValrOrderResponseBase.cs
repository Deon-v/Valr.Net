using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Trading
{
    public class ValrOrderResponseBase
    {
        [JsonProperty("orderId")]
        public Guid Id { get; set; }

        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("orderStatusType")]
        public ValrOrderStatus Status { get; set; }

        [JsonProperty("orderSide")]
        public ValrOrderSide Side { get; set; }

        [JsonProperty("originalPrice")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("remainingQuantity")]
        public decimal RemainingQuantity { get; set; }

        [JsonProperty("originalQuantity")]
        public decimal OriginalQuantity { get; set; }

        [JsonProperty("orderType")]
        public ValrOrderType Type { get; set; }

        [JsonProperty("orderUpdatedAt")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("orderCreatedAt")]
        public DateTime Created { get; set; }
    }
}
