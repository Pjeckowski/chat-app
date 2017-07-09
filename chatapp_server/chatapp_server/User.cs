using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    /// <summary>
    /// Object that ll contain User's ID, Nickname, Password, Email, Room penalties Etc.
    /// </summary>
    class User
    {
        public uint ID { get; private set; }

        public string Nickname { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public User( uint ID, string Nickname, string Email, string Password)
        {
            this.ID = ID;
            this.Nickname = Nickname;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
