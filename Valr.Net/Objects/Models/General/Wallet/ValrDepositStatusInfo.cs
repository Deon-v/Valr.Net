using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrDepositStatusInfo
    {
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("receiveAddress")]
        public string ReceiveAddress { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("confirmedAt")]
        public DateTime? ConfirmedAt { get; set; }
    }
}
