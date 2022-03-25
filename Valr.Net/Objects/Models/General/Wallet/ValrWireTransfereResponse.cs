using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWireTransferResponse
    {
        [JsonProperty("id")]
        public Guid TransactionId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }

        [JsonProperty("wireBankAccountId")]
        public Guid WireBankAccountId { get; set; }
    }
}
