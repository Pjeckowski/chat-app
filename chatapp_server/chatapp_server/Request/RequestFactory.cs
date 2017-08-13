using System;


namespace chatapp_server
{
    public class RequestFactory
    {
        public IRequest GetRequest(User CallingUser, IPacket packet)
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
                    return null;

                case RequestType.MESSAGE:
                    return null;

                case RequestType.PRIVATE_MESSAGE:
                    return null;

                default:
                    return null;
            }   
        }

    }
}
