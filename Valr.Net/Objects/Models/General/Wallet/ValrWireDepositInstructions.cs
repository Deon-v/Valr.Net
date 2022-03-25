using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Wallet
{
    public class ValrWireDepositInstructions
    {
        [JsonProperty("trackingReference")]
        public string TrackingReference { get; set; }

        [JsonProperty("beneficiary")]
        public Beneficiary Beneficiary { get; set; }

        [JsonProperty("beneficiaryBank")]
        public BeneficiaryBank BeneficiaryBank { get; set; }
    }

    public class Beneficiary
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address1")]
        public string? Address1 { get; set; }

        [JsonProperty("address2")]
        public string? Address2 { get; set; }
    }

    public class BeneficiaryBank
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("swiftCode")]
        public string? SwiftCode { get; set; }

        [JsonProperty("routingNumber")]
        public string? RoutingNumber { get; set; }

        [JsonProperty("accountNumber")]
        public string? AccountNumber { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("postalCode")]
        public string? PostalCode { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }
    }

}
