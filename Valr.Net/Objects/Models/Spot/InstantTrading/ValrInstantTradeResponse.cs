using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.InstantTrading
{
    public class ValrInstantTradeResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
