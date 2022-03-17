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
    }
}
