using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    public class LoginRequest :Request
    {

        public string UserName { get; private set; }
        public string UserPassword { get; private set; }

        public LoginRequest(string UserName, string UserPassword)
        {
            this.UserName = UserName;
            this.UserPassword = UserPassword;
        }
    }
}
