using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWalletAddress
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
