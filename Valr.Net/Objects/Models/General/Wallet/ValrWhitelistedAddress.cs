using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWhitelistedAddress : ValrWalletAddress
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
