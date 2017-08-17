using System;


namespace chatapp_server
{
    public class RequestFactory
    {
        public IRequest GetRequest(IUser CallingUser, IPacket packet)
        {
            switch (packet.Header)
            {
                case RequestType.LOGIN:
                    try
                    {
                        return new LoginRequest(packet.Body);
                    }
                    catch(ArgumentException)
                    {
                        return null;
                    }
                    // is that ok what I just did here??
                case RequestType.KICK:
                    try
                    {
                        return new KickRequest(CallingUser, packet.Body);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }

                case RequestType.MESSAGE:
                    try
                    {
                        return new MessageRequest(CallingUser, packet.Body);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }

                case RequestType.PRIVATE_MESSAGE:
                    try
                    {
                        return new MessageRequest(CallingUser, packet.Body);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }

                case RequestType.ROOM_ENTER:
                    try
                    {
                        return new RoomEnterRequest(CallingUser, packet.Body);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }

                default:
                    return null;
            }   
        }

    }
}
