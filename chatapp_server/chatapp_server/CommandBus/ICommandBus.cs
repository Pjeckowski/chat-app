using chatapp_server.Commands;

namespace chatapp_server.CommandBus
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
