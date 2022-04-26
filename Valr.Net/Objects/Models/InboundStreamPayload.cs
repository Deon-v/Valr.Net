using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models
{
    public class InboundStreamPayload<T>
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("currencyPairSymbol")]
        public string? Symbol { get; set; }
    }
}
