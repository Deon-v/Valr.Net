using Newtonsoft.Json;

namespace Valr.Net.Enums
{
    public enum ValrStatus
    {
        [JsonProperty("online")]
        Online,
        [JsonProperty("read-only")]
        ReadOnly,
        [JsonProperty("offline")]
        Offline
    }
}
