using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    public class KickRequest :Request
    {
        public User CallingUser { get; private set; }
        public string KickUserName { get; private set; }

        public KickRequest(User CallingUser, string KickUserName)
        {
            this.CallingUser = CallingUser;
            this.KickUserName = KickUserName;                
        }
        
    }
}
