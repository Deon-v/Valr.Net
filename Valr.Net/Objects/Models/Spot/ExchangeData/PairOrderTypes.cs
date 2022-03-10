using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.ExchangeData
{
    public class PairOrderTypes
    {
        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("orderTypes")]
        public ValrOrderType[] OrderTypes { get; set; }
    }

    public class PairOrderTypesWrapper
    {
        public PairOrderTypes[] PairOrderTypes { get; set; }
    }
}
