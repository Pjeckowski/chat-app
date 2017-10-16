using System.Threading.Tasks;
using Chat_Protocol.Commands;

namespace chatapp_server.CommandBus
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
