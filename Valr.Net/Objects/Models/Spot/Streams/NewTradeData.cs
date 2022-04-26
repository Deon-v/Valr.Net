using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Streams;

public class NewTradeData
{
    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("quantity")]
    public decimal Quantity { get; set; }

    [JsonProperty("currencyPair")]
    public string Symbol { get; set; }

    [JsonProperty("tradedAt")]
    public DateTime Created { get; set; }

    [JsonProperty("takerSide")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ValrOrderSide Side { get; set; }
}