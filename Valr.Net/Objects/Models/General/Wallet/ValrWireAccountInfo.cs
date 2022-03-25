using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWireAccountInfo
    {
        [JsonProperty("")]
        public Guid id { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("routingNumber")]
        public string RoutingNumber { get; set; }

        [JsonProperty("billingDetails")]
        public Billingdetails BillingDetails { get; set; }

        [JsonProperty("bankAddress")]
        public Bankaddress BankAddress { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }
    }

    public class Billingdetails
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("line1")]
        public string? Line1 { get; set; }

        [JsonProperty("line2")]
        public string? Line2 { get; set; }

        [JsonProperty("district")]
        public string? District { get; set; }

        [JsonProperty("postalCode")]
        public string? PostalCode { get; set; }
    }

    public class Bankaddress
    {
        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("line1")]
        public string? Line1 { get; set; }

        [JsonProperty("line2")]
        public string? Line2 { get; set; }

        [JsonProperty("district")]
        public string? District { get; set; }
    }

}
