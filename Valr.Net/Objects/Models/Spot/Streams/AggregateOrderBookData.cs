using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Streams;

public class AggregateOrderBookData
{
    [JsonProperty("Asks")]
    public AggregateOrder[] Asks { get; set; }

    [JsonProperty("Bids")]
    public AggregateOrder[] Bids { get; set; }

    [JsonProperty("LastChange")]
    public DateTime LastChange { get; set; }

    [JsonProperty("SequenceNumber")]
    public int SequenceNumber { get; set; }
}

public class AggregateOrder
{
    [JsonProperty("side")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ValrOrderSide Side { get; set; }

    [JsonProperty("quantity")]
    public decimal Quantity { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("currencyPair")]
    public string Symbol { get; set; }

    [JsonProperty("orderCount")]
    public int OrderCount { get; set; }
}