namespace Valr.Net.Interfaces.Clients.SpotApi
{
    public interface IValrClientSpotApi
    {
        /// <summary>
        /// Endpoints related to requesting data for general exchange data
        /// </summary>
        public IValrClientSpotApiTrading Spot { get; }
    }
}
