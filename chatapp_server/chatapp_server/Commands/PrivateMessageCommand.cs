using System;
using chatapp_server.Commands;
using chatapp_server.Users;

namespace chatapp_server.RequestPacket
{
    public class PrivateMessageCommand : ICommand
    {
        public IUser CallingUser { get; private set; }
        public string TargetUserName { get; private set; }
        public string Message { get; private set; }
    }
}
