using System.ComponentModel;

namespace chatapp_server.RequestPacket
{
    public enum RequestType
    {
        [Description("It doesnt matter")]
        CORRUPTED,
        [Description("k")]
        KICK,
        [Description("l")]
        LOGIN,
        [Description("m")]
        MESSAGE,
        [Description("p")]
        PRIVATE_MESSAGE,
        [Description("r")]
        ROOM_ENTER,
        [Description("s")]
        ROOM_LEAVE
    }
}
