using CryptoExchange.Net.Objects;
using Valr.Net.Interfaces.Clients;

namespace Valr.Net.Objects.Options
{
    public class ValrOrderBookOptions : OrderBookOptions
    {
        /// <summary>
        /// Update interval in milliseconds, either 100 or 1000. Defaults to 1000
        /// </summary>
        public int? UpdateInterval { get; set; }

        /// <summary>
        /// After how much time we should consider the connection dropped if no data is received for this time after the initial subscriptions
        /// </summary>
        public TimeSpan? InitialDataTimeout { get; set; }

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
