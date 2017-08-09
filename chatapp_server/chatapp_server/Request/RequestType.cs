using System.ComponentModel;

namespace chatapp_server.Request
{
    public enum RequestType
    {
        [Description("Corrupted")]
        CORRUPTED,
        [Description("Kick")]
        KICK,
        [Description("Login")]
        LOGIN,
        [Description("Message")]
        MESSAGE,
        [Description("PrivateMessage")]
        PRIVATE_MESSAGE
    }
}
