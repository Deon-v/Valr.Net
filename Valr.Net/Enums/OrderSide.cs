using Newtonsoft.Json;

namespace Valr.Net.Enums
{
    public enum OrderSide
    {
        [JsonProperty("buy")]
        Buy,
        [JsonProperty("sell")]
        Sell
    }
}
