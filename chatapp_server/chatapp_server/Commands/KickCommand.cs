using System;
using chatapp_server.Commands;
using chatapp_server.Users;

namespace chatapp_server.Commands
{
    public class KickCommand : ICommand
    {

        public IUser CallingUser { get; private set; }
        public string KickUserName { get; private set; }

    }
}
