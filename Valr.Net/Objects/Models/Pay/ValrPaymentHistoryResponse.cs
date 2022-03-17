using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Pay
{
    public class ValrPaymentHistoryResponse
    {
        [JsonProperty("identifier")]
        public Guid Id { get; set; }

        [JsonProperty("otherPartyIdentifier")]
        public string OtherPartyIdentifier { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("status")]
        public ValrPaymentStatus Status { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("anonymous")]
        public bool Anonymous { get; set; }

        [JsonProperty("type")]
        public ValrPaymentType Type { get; set; }

        [JsonProperty("senderNote")]
        public string SenderNote { get; set; }

        [JsonProperty("recipientNote")]
        public string RecipientNote { get; set; }
    }
}
