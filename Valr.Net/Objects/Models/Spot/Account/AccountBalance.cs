using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.Account
{
    public class AccountBalance
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("available")]
        public decimal Available { get; set; }
        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }
        public DateTime updatedAt { get; set; }
    }


    public class AccountBalanceWrapper
    {
        public AccountBalance[] Balances { get; set; }
    }
}
