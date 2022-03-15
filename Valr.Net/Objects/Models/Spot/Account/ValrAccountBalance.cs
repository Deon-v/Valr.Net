using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.Account
{
    public class ValrAccountBalance
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("available")]
        public decimal Available { get; set; }
        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }


    public class AccountBalanceWrapper
    {
        public ValrAccountBalance[] Balances { get; set; }
    }
}
