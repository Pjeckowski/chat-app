using System;
using chatapp_server.Users;

namespace chatapp_server.RequestPacket
{
    class RoomEnterRequest : IRequestCommand
    {
        public IUser CallingUser { get; private set; }
        public string RoomName { get; private set; }

        public RoomEnterRequest(IUser CallingUser ,string data)
        {
            if (!IsValid(data))
            {
                throw new ArgumentException();
            }

            this.CallingUser = CallingUser;
            RoomName = data;
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
