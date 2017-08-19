using System;
using chatapp_server.Exceptions;
using chatapp_server.Users;
using chatapp_server.UtilPacket;

namespace chatapp_server.RequestPacket
{
    public class RequestFactory : INetworkCommandFactory
    {

        public INetworkCommand GetNetworkCommand(IUser callingUser, Enum requestType, string body)
        {
            if(!(requestType is RequestType))
                throw new ArgumentException("Request does not contain valid type.");

            var rType = (RequestType) requestType;
            
            switch (rType)
            {
                case RequestType.LOGIN:
                    return new LoginRequest(body);

                case RequestType.KICK:
                    return new KickRequest(callingUser, body);


                case RequestType.MESSAGE:
                    return new MessageRequest(callingUser, body);


                case RequestType.PRIVATE_MESSAGE:
                    return new MessageRequest(callingUser, body);


                case RequestType.ROOM_ENTER:
                    return new RoomEnterRequest(callingUser, body);

                default:
                    throw new NoSuchRequestException();
        }
    }
    }
}
