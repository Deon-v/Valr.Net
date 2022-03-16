using System.Runtime.Serialization;

namespace Valr.Net.Enums
{
    public enum ValrOrderSide
    {
        [EnumMember(Value = "buy")]
        Buy,
        [EnumMember(Value = "sell")]
        Sell
    }
}
