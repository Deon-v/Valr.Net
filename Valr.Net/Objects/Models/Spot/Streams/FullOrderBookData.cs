using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.Streams;

public class FullOrderBookData
{
    [JsonProperty("LastChange")]
    public long LastChange { get; set; }

    [JsonProperty("Asks")]
    public Order[] Asks { get; set; }

    [JsonProperty("Bids")]
    public Order[] Bids { get; set; }

    [JsonProperty("SequenceNumber")]
    public int SequenceNumber { get; set; }
}

public class Order
{
    [JsonProperty("Price")]
    public decimal Price { get; set; }

    [JsonProperty("Orders")]
    public OrderDetails[] Orders { get; set; }
}

public class OrderDetails
{
    [JsonProperty("orderId")]
    public Guid Id { get; set; }

    [JsonProperty("quantity")]
    public decimal Quantity { get; set; }
}
