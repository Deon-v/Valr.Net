using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class FailedOrderCancellationData
    {
        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

}
