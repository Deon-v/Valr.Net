using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class OrderProcessedPayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }
        public ProcessedOrderData data { get; set; }
    }
    public class ProcessedOrderData
    {
        public string orderId { get; set; }
        public bool success { get; set; }
        public string failureReason { get; set; }
    }

}
