using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    public class Admin : User
    {
        public Admin(uint ID, string Nickname, string Email, string Password)
           : base(ID, Nickname, Email, Password)
        {

        }
        public override bool IsAdmin()
        {
            return true;
        }
    }
}
