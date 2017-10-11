using System;
using chatapp_server.Commands;
using chatapp_server.Users;

namespace chatapp_server.RequestPacket
{
    class RoomEnterCommand : ICommand
    {
        public IUser CallingUser { get; private set; }
        public string RoomName { get; private set; }
    }
}
