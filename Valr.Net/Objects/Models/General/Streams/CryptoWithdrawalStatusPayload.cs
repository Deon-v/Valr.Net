using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class CryptoWithdrawalStatusPayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }

        [JsonProperty("data")]
        public CryptoWithdrawalStatusData Data { get; set; }
    }

    public class CryptoWithdrawalStatusData
    {
        [JsonProperty("uniqueId")]
        public Guid Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }
    }

}
