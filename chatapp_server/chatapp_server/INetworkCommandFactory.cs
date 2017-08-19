using System;
using chatapp_server.Users;

namespace chatapp_server
{
    public interface INetworkCommandFactory
    {
        INetworkCommand GetNetworkCommand(IUser callingUser, Enum commandType, string body);
    }
}
