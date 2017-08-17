using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    class RoomEnterRequest : IRequest
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
