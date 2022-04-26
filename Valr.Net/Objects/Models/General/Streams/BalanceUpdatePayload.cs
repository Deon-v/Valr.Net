using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class BalanceUpdateData
    {
        [JsonProperty("currency")]
        public CurrencyInfo Currency { get; set; }

        [JsonProperty("available")]
        public decimal Available { get; set; }

        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime ChangeTime { get; set; }
    }
}
