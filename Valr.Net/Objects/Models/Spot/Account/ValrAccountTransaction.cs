using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Account
{
    public class ValrAccountTransaction
    {
        [JsonProperty("transactionType")]
        public Transactiontype TransactionType { get; set; }

        [JsonProperty("debitCurrency")]
        public string DebitCurrency { get; set; }

        [JsonProperty("debitValue")]
        public string DebitValue { get; set; }

        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("feeValue")]
        public decimal Fee { get; set; }

        [JsonProperty("eventAt")]
        public DateTime TransactionTime { get; set; }

        [JsonProperty("additionalInfo")]
        public Additionalinfo AdditionalInfo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }


    public class AccountTransactionWrapper
    {
        public ValrAccountTransaction[] Transactions { get; set; }
    }

    public class Transactiontype
    {
        [JsonProperty("type")]
        public ValrTransactionType Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Additionalinfo
    {
        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
    }

}
