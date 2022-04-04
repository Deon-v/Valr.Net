using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using Valr.Net.Interfaces.Clients.SpotApi;
using Valr.Net.Objects.Options;

namespace Valr.Net.Clients.SpotApi
{
    public class ValrSocketClientSpotStreams : SocketApiClient, IValrSocketClientSpotStreams
    {
        #region fields
        private readonly ValrSocketClient _baseClient;
        private readonly Log _log;
        #endregion

        #region constructor/destructor

        /// <summary>
        /// Create a new instance of ValrSocketClientSpotStreams with default options
        /// </summary>
        public ValrSocketClientSpotStreams(Log log, ValrSocketClient baseClient, ValrSocketClientOptions options) :
            base(options, options.GeneralStreamsOptions)
        {
            _baseClient = baseClient;
            _log = log;
        }
        #endregion

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new ValrAuthenticationProvider(credentials);
    }
}
