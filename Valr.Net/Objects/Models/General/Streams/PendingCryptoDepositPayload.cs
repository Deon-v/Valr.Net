using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class PendingCryptoDepositData
    {
        [JsonProperty("currency")]
        public CurrencyInfo Currency { get; set; }

        [JsonProperty("receiveAddress")]
        public string ReceiveAddress { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }
    }
}
