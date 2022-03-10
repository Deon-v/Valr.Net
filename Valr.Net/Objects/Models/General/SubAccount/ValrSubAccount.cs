using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.SubAccount
{
    public class ValrSubAccount
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    internal class ValrSubAccountWrapper
    {
        public IEnumerable<ValrSubAccount>? SubAccounts { get; set; }
    }
}
