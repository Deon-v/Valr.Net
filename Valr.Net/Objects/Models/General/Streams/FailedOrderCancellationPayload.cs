using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class FailedOrderCancellationPayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }

        [JsonProperty("data")]
        public FailedOrderCancellationData Data { get; set; }
    }

    public class FailedOrderCancellationData
    {
        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

}
