using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWithdrawalStatusInfo
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("feeAmount")]
        public string FeeAmount { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("lastConfirmationAt")]
        public DateTime LastConfirmationTime { get; set; }

        [JsonProperty("uniqueId")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("status")]
        public ValrWithdrawalStatus Status { get; set; }
    }
}
