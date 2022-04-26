using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class OrderUpdateData
    {
        [JsonProperty("orderId")]
        public Guid Id { get; set; }

        [JsonProperty("orderStatusType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValrOrderStatus OrderStatus { get; set; }

        [JsonProperty("currencyPair")]
        public Currencypair Symbol { get; set; }

        [JsonProperty("originalPrice")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("remainingQuantity")]
        public decimal RemainingQuantity { get; set; }

        [JsonProperty("originalQuantity")]
        public decimal OriginalQuantity { get; set; }

        [JsonProperty("orderSide")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValrOrderSide Side { get; set; }

        [JsonProperty("orderType")]
        public ValrOrderType OrderType { get; set; }

        [JsonProperty("failedReason")]
        public string? FailedReason { get; set; }

        [JsonProperty("orderUpdatedAt")]
        public DateTime Updated { get; set; }

        [JsonProperty("orderCreatedAt")]
        public DateTime Created { get; set; }

        [JsonProperty("customerOrderId")]
        public string? CustomerOrderId { get; set; }
    }
}
