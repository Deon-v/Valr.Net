using CryptoExchange.Net.Interfaces;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Interfaces.Clients.SpotApi;

namespace Valr.Net.Interfaces.Clients
{
    public interface IValrSocketClient : ISocketClient
    {
        /// <summary>
        /// Spot streams
        /// </summary>
        IValrSocketClientSpotStreams SpotStreams { get; }

        /// <summary>
        /// General streams
        /// </summary>
        IValrSocketClientGeneralStreams GeneralStreams { get; }
    }
}
