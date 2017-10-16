using System;
using System.Threading.Tasks;
using Chat_Protocol.Commands;

namespace chatapp_server.CommandHandlers
{
    public class MessageCommandHandler : IHandleCommandG<MessageCommand> 
    {
        public Task HandleAsync(MessageCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
