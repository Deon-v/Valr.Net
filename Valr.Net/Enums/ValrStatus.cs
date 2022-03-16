using System.Runtime.Serialization;

namespace Valr.Net.Enums
{
    public enum ValrStatus
    {
        [EnumMember(Value = "online")]
        Online,
        [EnumMember(Value = "read-only")]
        ReadOnly,
        [EnumMember(Value = "offline")]
        Offline
    }
}
