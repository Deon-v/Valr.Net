using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Pay
{
    public class ValrPaymentResponse
    {
        [JsonProperty("identifier")]
        public Guid Id { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
    }
}
