using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrFiatDepositReference
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
