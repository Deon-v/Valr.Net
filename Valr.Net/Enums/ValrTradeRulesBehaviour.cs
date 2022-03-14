namespace Valr.Net.Enums
{
    public enum ValrTradeRulesBehaviour
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Throw an error if not complying
        /// </summary>
        ThrowError,
        /// <summary>
        /// Auto adjust order when not complying
        /// </summary>
        AutoComply
    }
}
