using System.Threading.Tasks;
using Chat_Protocol.Commands;

namespace chatapp_server.CommandHandlers
{
    public interface IHandleCommandG<TCommand> : IHandleCommand where TCommand: ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
