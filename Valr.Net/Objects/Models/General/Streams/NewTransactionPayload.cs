using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class NewTransactionData
    {
        [JsonProperty("transactionType")]
        public Transactiontype TransactionType { get; set; }

        [JsonProperty("debitCurrency")]
        public CurrencyData DebitCurrency { get; set; }

        [JsonProperty("debitValue")]
        public decimal DebitValue { get; set; }

        [JsonProperty("creditCurrency")]
        public CurrencyData CreditCurrency { get; set; }

        [JsonProperty("creditValue")]
        public decimal CreditValue { get; set; }

        [JsonProperty("feeCurrency")]
        public CurrencyData FeeInfo { get; set; }

        [JsonProperty("feeValue")]
        public decimal FeeValue { get; set; }

        [JsonProperty("eventAt")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("additionalInfo")]
        public Additionalinfo Additionalinfo { get; set; }

    }

    public class Transactiontype
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class CurrencyData
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("decimalPlaces")]
        public int DecimalPlaces { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }

        [JsonProperty("supportedWithdrawDecimalPlaces")]
        public int SupportedWithdrawDecimalPlaces { get; set; }
    }

    public class Additionalinfo
    {
        [JsonProperty("costPerCoin")]
        public int CostPerCoin { get; set; }

        [JsonProperty("costPerCoinSymbol")]
        public string CostPerCoinSymbol { get; set; }

        [JsonProperty("currencyPairSymbol")]
        public string CurrencyPairSymbol { get; set; }
    }
}
