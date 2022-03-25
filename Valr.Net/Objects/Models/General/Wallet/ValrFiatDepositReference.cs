using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrFiatDepositReference
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
