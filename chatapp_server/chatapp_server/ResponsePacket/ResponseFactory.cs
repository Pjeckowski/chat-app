using System;
using chatapp_server.Users;

namespace chatapp_server.ResponsePacket
{
    public class ResponseFactory : INetworkCommandFactory
    {
        public INetworkCommand GetNetworkCommand(IUser callingUser, Enum responseType, string body)
        {
            throw new NotImplementedException();
        }
    }
}
