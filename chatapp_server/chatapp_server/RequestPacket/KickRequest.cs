using System;
using chatapp_server.Users;

namespace chatapp_server.RequestPacket
{
    public class KickRequest : IRequestCommand
    {

        public IUser CallingUser { get; private set; }
        public string KickUserName { get; private set; }

        public KickRequest(IUser CallingUser, string data)
        {
            if(!IsValid(data))
            {
                throw new ArgumentException();
            }
            this.CallingUser = CallingUser;
            this.KickUserName = data;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        private bool IsValid(string data)
        {
            return false;
        }
    }
}
