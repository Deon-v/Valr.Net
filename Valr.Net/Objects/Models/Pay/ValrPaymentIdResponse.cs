using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Pay
{
    public class ValrPaymentIdResponse
    {
        [JsonProperty("payId")]
        public string PayId { get; set; }

    }
}
