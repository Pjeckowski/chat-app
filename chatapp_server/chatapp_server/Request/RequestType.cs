using System.ComponentModel;

namespace chatapp_server
{
    public enum RequestType
    {
        [Description("k")]
        KICK,
        [Description("l")]
        LOGIN,
        [Description("m")]
        MESSAGE,
        [Description("p")]
        PRIVATE_MESSAGE
    }
}
