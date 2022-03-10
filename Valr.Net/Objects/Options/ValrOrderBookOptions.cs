using CryptoExchange.Net.Objects;
using Valr.Net.Interfaces.Clients;

namespace Valr.Net.Objects.Options
{
    public class ValrOrderBookOptions : OrderBookOptions
    {
        /// <summary>
        /// The rest client to use for requesting the initial order book
        /// </summary>
        public IValrClient? RestClient { get; set; }

        /// <summary>
        /// The client to use for the socket connection. When using the same client for multiple order books the connection can be shared.
        /// </summary>
        public IValrSocketClient? SocketClient { get; set; }
    }
}
