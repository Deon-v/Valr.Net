using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.Trading
{
    public class ValrOrderStatusResponse : ValrOrderResponseBase
    {
        [JsonProperty("failedReason")]
        public string FailedReason { get; set; }

        [JsonProperty("customerOrderId")]
        public int CustomerOrderId { get; set; }
    }
}
