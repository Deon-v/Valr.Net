using Newtonsoft.Json;

namespace Valr.Net.Enums
{
    public enum ValrOrderSide
    {
        [JsonProperty("buy")]
        Buy,
        [JsonProperty("sell")]
        Sell
    }
}
