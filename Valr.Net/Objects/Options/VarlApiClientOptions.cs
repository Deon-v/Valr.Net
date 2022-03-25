using CryptoExchange.Net.Objects;
using Valr.Net.Enums;

namespace Valr.Net.Objects.Options
{
    public class ValrApiClientOptions : RestApiClientOptions
    {
        /// <summary>
        /// A manual offset for the timestamp. Should only be used if AutoTimestamp and regular time synchronization on the OS is not reliable enough
        /// </summary>
        public TimeSpan TimestampOffset { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Whether to check the trade rules when placing new orders and what to do if the trade isn't valid
        /// </summary>
        public ValrTradeRulesBehaviour TradeRulesBehaviour { get; set; } = ValrTradeRulesBehaviour.None;
        /// <summary>
        /// How often the trade rules should be updated. Only used when TradeRulesBehaviour is not None
        /// </summary>
        public TimeSpan TradeRulesUpdateInterval { get; set; } = TimeSpan.FromMinutes(60);

        /// <summary>
        /// ctor
        /// </summary>
        public ValrApiClientOptions()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress"></param>
        internal ValrApiClientOptions(string baseAddress) : base(baseAddress)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn"></param>
        /// <param name="newValues"></param>
        internal ValrApiClientOptions(ValrApiClientOptions baseOn, ValrApiClientOptions? newValues) : base(baseOn, newValues)
        {
            TimestampOffset = newValues?.TimestampOffset ?? baseOn.TimestampOffset;
            TradeRulesBehaviour = newValues?.TradeRulesBehaviour ?? baseOn.TradeRulesBehaviour;
            TradeRulesUpdateInterval = newValues?.TradeRulesUpdateInterval ?? baseOn.TradeRulesUpdateInterval;
        }
    }
}
