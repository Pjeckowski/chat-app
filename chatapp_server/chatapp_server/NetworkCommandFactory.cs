using chatapp_server.Network;
using chatapp_server.RequestPacket;
using chatapp_server.ResponsePacket;

namespace chatapp_server
{
    public class NetworkCommandFactory
    {
        private RequestFactory requestFactory;
        private ResponseFactory responseFactory;
        private UtilityFactory utilityFactory;

        public INetworkCommandFactory GetFactory(PacketType packetType)
        {
            switch (packetType)
            {
                case PacketType.REQUEST:
                {
                    return requestFactory ?? (requestFactory = new RequestFactory());
                }
                case PacketType.RESPONSE:
                {
                    return responseFactory ?? (responseFactory = new ResponseFactory());
                }
                case PacketType.UTILITY:
                {
                    return utilityFactory ?? (utilityFactory = new UtilityFactory());
                }

                default: return null;
            }
        }
    }
}