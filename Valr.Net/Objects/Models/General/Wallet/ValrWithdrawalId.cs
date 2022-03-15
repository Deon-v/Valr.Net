using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWithdrawalId
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
