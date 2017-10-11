using System;
using System.Threading.Tasks;
using chatapp_server.CommandHandlers;
using chatapp_server.Commands;

namespace chatapp_server.CommandBus
{
    public class CommandBus :ICommandBus
    {
        private readonly Func<Type, IHandleCommand> handlersFactory;

        public CommandBus(Func<Type,IHandleCommand> handlersFactory)
        {
            this.handlersFactory = handlersFactory;
        }

        public async void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            IHandleCommandG<TCommand> handler = (IHandleCommandG<TCommand>) handlersFactory(typeof(TCommand));
            await handler.HandleAsync(command);
        }
    }
}
