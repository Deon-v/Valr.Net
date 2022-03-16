using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.Trading
{
    public class ValrPlaceOrderResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
