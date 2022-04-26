using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    internal class ValrSocketRequest
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValrSocketEventType EventType { get; set; }

        [JsonProperty("subscriptions")]
        public Subscription[] Subscriptions { get; set; }
    }

    public class Subscription
    {
        [JsonProperty("event")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValrSocketOutboundEvent Event { get; set; }

        [JsonProperty("pairs")]
        public string[] pairs { get; set; }
    }
}
