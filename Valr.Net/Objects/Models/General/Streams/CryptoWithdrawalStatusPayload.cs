using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class CryptoWithdrawalStatusData
    {
        [JsonProperty("uniqueId")]
        public Guid Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }
    }

}
