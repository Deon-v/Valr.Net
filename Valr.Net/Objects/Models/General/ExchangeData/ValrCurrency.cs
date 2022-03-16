using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.General.ExchangeData
{
    public class ValrCurrency
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }

        [JsonProperty("decimalPlaces")]
        public int DecimalPlaces { get; set; }

        [JsonProperty("withdrawalDecimalPlaces")]
        public int WithdrawalDecimalPlaces { get; set; }
    }

    public class ValrCurrencyWrapper
    {
        public ValrCurrency[] ValrCurrencies { get; set; }
    }

}
