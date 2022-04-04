using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class BalanceUpdatePayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }

        [JsonProperty("data")]
        public BalanceUpdateData Data { get; set; }
    }

    public class BalanceUpdateData
    {
        [JsonProperty("currency")]
        public CurrencyInfo Currency { get; set; }

        [JsonProperty("available")]
        public decimal Available { get; set; }

        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime ChangeTime { get; set; }
    }
}
