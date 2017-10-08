using System;
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

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            IHandleCommandG<TCommand> handler = (IHandleCommandG<TCommand>) handlersFactory(typeof(TCommand));
            handler.Handle(command);
        }
    }
}
