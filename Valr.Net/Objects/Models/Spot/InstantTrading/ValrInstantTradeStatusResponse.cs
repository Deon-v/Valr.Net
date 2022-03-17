using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.InstantTrading
{
    public class ValrInstantTradeStatusResponse
    {
        [JsonProperty("orderId")]
        public Guid Id { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("processing")]
        public decimal Processing { get; set; }

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
        public DateTime TimeExecuted { get; set; }
    }
}
