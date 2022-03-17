using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Pay
{
    public class ValrPaymentLimitResponse
    {
        [JsonProperty("maxPaymentAmount")]
        public decimal MaxPaymentAmount { get; set; }

        [JsonProperty("minPaymentAmount")]
        public decimal MinPaymentAmount { get; set; }

        [JsonProperty("paymentCurrency")]
        public string PaymentCurrency { get; set; }

        [JsonProperty("limitType")]
        public string LimitType { get; set; }
    }
}
