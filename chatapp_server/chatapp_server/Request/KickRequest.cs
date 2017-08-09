using System;

namespace chatapp_server
{
    public class KickRequest : IRequest
    {
        private static readonly string KICK_REQUEST = "kick";

        public User CallingUser { get; private set; }
        public string KickUserName { get; private set; }

        public KickRequest(User CallingUser, string KickUserName)
        {
            this.CallingUser = CallingUser;
            this.KickUserName = KickUserName;                
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        private bool IsValid(string CommandBody)
        {
            return 0 == CommandBody.IndexOf(KICK_REQUEST, StringComparison.Ordinal);
        }
    }
}
