using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrBankAccountInfo
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("accountHolder")]
        public string AccountHolder { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("branchCode")]
        public string BranchCode { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }
    }
}
