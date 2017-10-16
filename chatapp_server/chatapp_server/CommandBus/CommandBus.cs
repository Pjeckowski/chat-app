using System;
using System.Threading.Tasks;
using Chat_Protocol.Commands;
using chatapp_server.CommandHandlers;


namespace chatapp_server.CommandBus
{
    public class CommandBus :ICommandBus
    {
        private readonly Func<Type, IHandleCommand> handlersFactory;

        public CommandBus(Func<Type,IHandleCommand> handlersFactory)
        {
            this.handlersFactory = handlersFactory;
        }

        public async Task Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (IHandleCommandG<TCommand>) handlersFactory(typeof(TCommand));
            await handler.HandleAsync(command);
        }
    }
}
