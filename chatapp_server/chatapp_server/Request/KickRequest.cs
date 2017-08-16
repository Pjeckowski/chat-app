using System;

namespace chatapp_server
{
    public class KickRequest : IRequest
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
            if(CallingUser is Admin)
            {
                if(string.Empty != data && null != data)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
