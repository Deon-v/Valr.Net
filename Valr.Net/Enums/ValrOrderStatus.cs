using System.Runtime.Serialization;

namespace Valr.Net.Enums;

public enum ValrOrderStatus
{
    Open,
    Active,
    [EnumMember(Value = "Partially Filled")]
    PartiallyFilled,
    Filled,
    Cancelled,
    Failed
}