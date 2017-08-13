using System;

namespace chatapp_server
{
    public class KickRequest : IRequest
    {

        public User CallingUser { get; private set; }
        public string KickUserName { get; private set; }

        public KickRequest(User CallingUser, string body)
        {
            this.CallingUser = CallingUser;
            this.KickUserName = body;                
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
