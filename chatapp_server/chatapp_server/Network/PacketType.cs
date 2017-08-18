using System.ComponentModel;

namespace chatapp_server
{
    public enum PacketType
    {
        [Description("")]
        CORRUPTED,
        [Description("r")]
        REQUEST,
        [Description("u")]
        UTILITY,
        [Description("s")]
        RESPONSE
    }
}
