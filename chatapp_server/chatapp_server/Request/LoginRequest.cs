using System;

namespace chatapp_server
{
    public class LoginRequest : IRequest
    {
        public string UserName { get; private set; }
        public string UserPassword { get; private set; }

        public LoginRequest(string data)
        {
            if (!IsValid(data))
            {
                throw new ArgumentException();
            }
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        private bool IsValid(string data)
        {
            return false;
        }
    }
}
