using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class NewTransactionPayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }

        [JsonProperty("data")]
        public NewTransactionData Data { get; set; }
    }
    public class NewTransactionData
    {
        [JsonProperty("type")]
        public Transactiontype transactionType { get; set; }

        [JsonProperty("type")]
        public CurrencyData debitCurrency { get; set; }

        [JsonProperty("type")]
        public decimal debitValue { get; set; }

        [JsonProperty("type")]
        public CurrencyData creditCurrency { get; set; }

        [JsonProperty("type")]
        public decimal creditValue { get; set; }

        [JsonProperty("feeCurrency")]
        public FeeInfo FeeInfo { get; set; }

        [JsonProperty("type")]
        public decimal feeValue { get; set; }

        [JsonProperty("type")]
        public DateTime eventAt { get; set; }

        [JsonProperty("type")]
        public Additionalinfo additionalInfo { get; set; }

    }

    public class Transactiontype
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class CurrencyData
    {
        public string symbol { get; set; }
        public int decimalPlaces { get; set; }
        public bool isActive { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public int supportedWithdrawDecimalPlaces { get; set; }
    }

    public class FeeInfo
    {
        public string symbol { get; set; }
        public int decimalPlaces { get; set; }
        public bool isActive { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public int supportedWithdrawDecimalPlaces { get; set; }
    }

    public class Additionalinfo
    {
        public int costPerCoin { get; set; }
        public string costPerCoinSymbol { get; set; }
        public string currencyPairSymbol { get; set; }
    }
}
