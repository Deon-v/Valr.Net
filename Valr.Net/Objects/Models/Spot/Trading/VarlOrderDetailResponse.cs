using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Trading
{
    public class ValrOrderDetailResponse : ValrOrderResponseBase
    {
        [JsonProperty("failedReason")]
        public string FailedReason { get; set; }

        [JsonProperty("executedFee")]
        public decimal ExecutedFee { get; set; }

        [JsonProperty("executedPrice")]
        public decimal ExecutedPrice { get; set; }

        [JsonProperty("executedQuantity")]
        public decimal ExecutedQuantity { get; set; }

        [JsonProperty("timeInForce")]
        public ValrTimeInforce TimeInForce { get; set; }
    }
}
