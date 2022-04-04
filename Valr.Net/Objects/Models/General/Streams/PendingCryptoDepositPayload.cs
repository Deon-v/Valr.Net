using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class PendingCryptoDepositPayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }
        public Data data { get; set; }
    }

    public class PendingCryptoDepositData
    {
        public CurrencyInfo currency { get; set; }
        public string receiveAddress { get; set; }
        public string transactionHash { get; set; }
        public float amount { get; set; }
        public DateTime createdAt { get; set; }
        public int confirmations { get; set; }
        public bool confirmed { get; set; }
    }
}
