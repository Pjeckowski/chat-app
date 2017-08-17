using System;
using chatapp_server.Exceptions;


namespace chatapp_server
{
    public class RequestFactory
    {
        public IRequest GetRequest(IUser CallingUser, RequestType requestType, string body)
        {
            switch (requestType)
            {
                case RequestType.LOGIN:
                    return new LoginRequest(body);

                case RequestType.KICK:
                    return new KickRequest(CallingUser, body);
                

                case RequestType.MESSAGE:
                    return new MessageRequest(CallingUser, body);
                    

                case RequestType.PRIVATE_MESSAGE:
                    return new MessageRequest(CallingUser, body);
                   

                case RequestType.ROOM_ENTER:
                    return new RoomEnterRequest(CallingUser, body);

                default:
                    throw new NoSuchRequestException();
            }   
        }

    }
}
