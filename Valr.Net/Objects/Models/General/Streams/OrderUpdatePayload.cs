using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class OrderUpdatePayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string orderId { get; set; }
        public string orderStatusType { get; set; }
        public Currencypair currencyPair { get; set; }
        public string originalPrice { get; set; }
        public string remainingQuantity { get; set; }
        public string originalQuantity { get; set; }
        public string orderSide { get; set; }
        public string orderType { get; set; }
        public string failedReason { get; set; }
        public DateTime orderUpdatedAt { get; set; }
        public DateTime orderCreatedAt { get; set; }
        public string customerOrderId { get; set; }
    }
}
