using System;
using chatapp_server.Users;

namespace chatapp_server
{
    public class UtilityFactory : INetworkCommandFactory
    {
        public INetworkCommand GetNetworkCommand(IUser callingUser, Enum utilityType, string body)
        {
            throw new NotImplementedException();
        }
    }
}
