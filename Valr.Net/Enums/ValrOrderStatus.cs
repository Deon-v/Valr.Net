using System.Runtime.Serialization;

namespace Valr.Net.Enums;

public enum ValrOrderStatus
{
    Open,
    New,
    Active,
    [EnumMember(Value = "Partially Filled")]
    PartiallyFilled,
    Filled,
    Cancelled,
    Failed
}