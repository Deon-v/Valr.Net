using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWithdrawalInfo
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("minimumWithdrawAmount")]
        public decimal MinimumWithdrawAmount { get; set; }

        [JsonProperty("withdrawalDecimalPlaces")]
        public int WithdrawalDecimalPlaces { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("withdrawCost")]
        public decimal WithdrawCost { get; set; }

        [JsonProperty("supportsPaymentReference")]
        public bool SupportsPaymentReference { get; set; }
    }
}
