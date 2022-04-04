using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class InstantOrderCompletePayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }

        [JsonProperty("data")]
        public InstantOrderCompleteData Data { get; set; }
    }

    public class InstantOrderCompleteData
    {
        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("paidAmount")]
        public decimal PaidAmount { get; set; }

        [JsonProperty("paidCurrency")]
        public string PaidCurrency { get; set; }

        [JsonProperty("receivedAmount")]
        public decimal ReceivedAmount { get; set; }

        [JsonProperty("receivedCurrency")]
        public string ReceivedCurrency { get; set; }

        [JsonProperty("feeAmount")]
        public decimal FeeAmount { get; set; }

        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("orderExecutedAt")]
        public DateTime Created { get; set; }
    }

}
