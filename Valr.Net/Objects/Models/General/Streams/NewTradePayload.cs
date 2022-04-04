using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.General.Streams
{
    public class NewTradePayload
    {
        [JsonProperty("type")]
        public ValrSocketInboundEvent PayloadType { get; set; }

        [JsonProperty("currencyPairSymbol")]
        public string Symbol { get; set; }

        [JsonProperty("data")]
        public NewTradeData Data { get; set; }
    }

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

        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValrOrderSide Side { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }

}
