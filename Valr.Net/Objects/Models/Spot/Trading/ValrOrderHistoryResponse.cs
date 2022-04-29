using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Trading
{
    public class ValrOrderHistoryResponse : ValrOrderResponseBase
    {
        [JsonProperty("averagePrice")]
        public decimal AveragePrice { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("totalFee")]
        public decimal TotalFee { get; set; }

        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("failedReason")]
        public string FailedReason { get; set; }

        [JsonProperty("timeInForce")]
        public ValrTimeInforce TimeInForce { get; set; }

        public decimal QuantityFilled => OriginalQuantity - RemainingQuantity;
    }
}
