using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.SubAccount
{
    public class ValrSubAccountCreated
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
