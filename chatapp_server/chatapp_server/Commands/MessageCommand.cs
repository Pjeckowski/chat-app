using System;
using chatapp_server.Commands;
using chatapp_server.Users;

namespace chatapp_server.RequestPacket
{
    public class MessageCommand : ICommand
    {
        public IUser CallingUser { get; private set; }
        public string Message { get; private set; }
    }
}
