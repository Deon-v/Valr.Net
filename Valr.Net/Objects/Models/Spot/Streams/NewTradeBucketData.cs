using Newtonsoft.Json;

namespace Valr.Net.Objects.Models.Spot.Streams;

public class NewTradeBucketData
{
    [JsonProperty("currencyPairSymbol")]
    public string Symbol { get; set; }

    [JsonProperty("bucketPeriodInSeconds")]
    public int BucketPeriod { get; set; }

    [JsonProperty("startTime")]
    public DateTime StartTime { get; set; }

    [JsonProperty("open")]
    public decimal Open { get; set; }

    [JsonProperty("high")]
    public decimal High { get; set; }

    [JsonProperty("low")]
    public decimal Low { get; set; }

    [JsonProperty("close")]
    public decimal Close { get; set; }

    [JsonProperty("volume")]
    public decimal Volume { get; set; }

}