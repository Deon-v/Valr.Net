using Newtonsoft.Json;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Models.Spot.Account
{
    public class AccountTrade
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("tradedAt")]
        public DateTime TradeTime { get; set; }

        [JsonProperty("side")]
        public OrderSide Side { get; set; }

        [JsonProperty("sequenceId")]
        public int SequenceId { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }
    }


    public class AccountTradeWrapper
    {
        public AccountTrade[] Trades { get; set; }
    }

}
