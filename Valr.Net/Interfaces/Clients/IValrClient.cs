using CryptoExchange.Net.Interfaces;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Interfaces.Clients.PayApi;
using Valr.Net.Interfaces.Clients.SpotApi;

namespace Valr.Net.Interfaces.Clients
{
    public interface IValrClient : IRestClient
    {
        /// <summary>
        /// General API endpoints
        /// </summary>

        IValrClientGeneralApi GeneralApi { get; }
        /// <summary>
        /// Spot API endpoints
        /// </summary>
        IValrClientSpotApi SpotApi { get; }

        /// <summary>
        /// Valr Pay API endpoints
        /// </summary>
        IValrClientPayApi PaymentApi { get; }

    }
}
