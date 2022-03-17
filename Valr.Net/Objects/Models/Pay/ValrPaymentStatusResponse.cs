using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Pay
{
    public class ValrPaymentStatusResponse
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("status")]
        public ValrPaymentStatus Status { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
    }
}
