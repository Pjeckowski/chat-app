using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    public interface IUser
    {
        uint ID { get; }
        string Nickname { get; }
        string Email { get; }
        string Password { get; }
        bool IsAdmin();
    }
}
