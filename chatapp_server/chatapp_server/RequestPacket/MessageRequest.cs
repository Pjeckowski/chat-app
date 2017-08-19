using System;
using chatapp_server.Users;

namespace chatapp_server.RequestPacket
{
    public class MessageRequest : IRequestCommand
    {
        public IUser CallingUser { get; private set; }
        public string Message { get; private set; }

        public MessageRequest(IUser CallingUser, string data)
        {
            if(!IsValid(data))
            {
                throw new ArgumentException();
            }

            this.CallingUser = CallingUser;
            this.Message = data;

        }

        private bool IsValid(string data)
        {
            if(string.Empty != data && null != data)
            {
                return true;
            }
            return false;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
