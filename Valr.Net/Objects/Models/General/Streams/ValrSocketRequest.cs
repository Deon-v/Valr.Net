using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    internal class ValrSocketRequest
    {
        [JsonProperty("type")]
        public ValrSocketEventType EventType { get; set; }

        [JsonProperty("subscriptions")]
        public Subscription[] Subscriptions { get; set; }
    }

    public class Subscription
    {
        [JsonProperty("event")]
        public ValrSocketOutboundEvent Event { get; set; }

        [JsonProperty("pairs")]
        public string[] pairs { get; set; }
    }
}
