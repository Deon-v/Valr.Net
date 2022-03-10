namespace Valr.Net.Enums
{
    public enum ValrOrderType
    {
        ///<summary>Place a limit order on the Exchange that will either be added to the order book or, should it match, be cancelled completely</summary>
        LIMIT_POST_ONLY,
        ///<summary>Place a limit order on the Exchange</summary>
        LIMIT,
        ///<summary>Place a market order on the Exchange (only crypto-to-ZAR pairs)</summary>
        MARKET,
        ///<summary>Similar to a market order, but allows for crypto-to-crypto pairs</summary>
        SIMPLE,
        ///<summary>Place a limit order on the Exchange that limits the downside of holding a particular asset</summary>
        STOP_LOSS_LIMIT,
        ///<summary>Place a limit order on the Exchange to lock in the growth of holding a particular asset</summary>
        TAKE_PROFIT_LIMIT
    }
}
