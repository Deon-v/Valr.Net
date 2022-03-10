using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;

namespace Valr.Net.Objects.Options
{
    public class ValrClientOptions : BaseRestClientOptions
    {
        /// <summary>
        /// Default options for the spot client
        /// </summary>
        public static ValrClientOptions Default { get; set; } = new ValrClientOptions();

        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        private VarlApiClientOptions _spotApiOptions = new VarlApiClientOptions(ValrApiAddresses.Default.RestClientAddress)
        {
            AutoTimestamp = true,
            RateLimiters = new List<IRateLimiter>
            {
                new RateLimiter()
                    .AddApiKeyLimit(500, TimeSpan.FromMinutes(1),true,false)
                    .AddTotalRateLimit( 500, TimeSpan.FromMinutes(1))
            }
        };
        /// <summary>
        /// Spot API options
        /// </summary>
        public VarlApiClientOptions SpotApiOptions
        {
            get => _spotApiOptions;
            set => _spotApiOptions = new VarlApiClientOptions(_spotApiOptions, value);
        }
        /// <summary>
        /// ctor
        /// </summary>
        public ValrClientOptions() : this(Default)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn">Base the new options on other options</param>
        internal ValrClientOptions(ValrClientOptions baseOn) : base(baseOn)
        {
            if (baseOn == null)
                return;

            ReceiveWindow = baseOn.ReceiveWindow;

            _spotApiOptions = new VarlApiClientOptions(baseOn.SpotApiOptions, null);
        }
    }
}
