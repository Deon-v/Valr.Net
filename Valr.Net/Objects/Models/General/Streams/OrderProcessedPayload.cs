using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class ProcessedOrderData
    {
        [JsonProperty("orderId")]
        public Guid Id { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("failureReason")]
        public string? Reason { get; set; }
    }

}
