using CryptoExchange.Net.Interfaces.CommonClients;

namespace Valr.Net.Interfaces.Clients.SpotApi
{
    public interface IValrClientSpotApi : IDisposable
    {
        /// <summary>
        /// Endpoints related to requesting data and executing trades
        /// </summary>
        public IValrClientSpotApiTrading Spot { get; }

        /// <summary>
        /// Endpoints related to requesting data and executing instant trades
        /// </summary>
        public IValrClientSpotApiInstantTrading InstantTrade { get; }

        /// <summary>
        /// Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.
        /// </summary>
        /// <returns></returns>
        public ISpotClient CommonSpotClient { get; }
    }
}
