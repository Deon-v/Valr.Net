using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Trading
{
    public class ValrOpenOrderResponse : ValrOrderResponseBase
    {
        [JsonProperty("filledPercentage")]
        public decimal FilledPercentage { get; set; }

        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }

        [JsonProperty("timeInForce")]
        public ValrTimeInforce TimeInForce { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status")]
        private ValrOrderStatus status
        {
            set => Status = value;
        }

        [JsonProperty("price")]
        private decimal price
        {
            set => OriginalPrice = value;
        }

        [JsonProperty("updatedAt")]
        private DateTime UpdatedAt
        {
            set => LastUpdated = value;
        }

        [JsonProperty("createdAt")]
        private DateTime createdAt
        {
            set => Created = value;
        }
    }
}
