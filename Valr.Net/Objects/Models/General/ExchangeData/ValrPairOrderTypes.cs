using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.ExchangeData
{
    public class ValrPairOrderTypes
    {
        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("orderTypes")]
        public ValrOrderType[] OrderTypes { get; set; }
    }

    public class PairOrderTypesWrapper
    {
        public ValrPairOrderTypes[] PairOrderTypes { get; set; }
    }
}
