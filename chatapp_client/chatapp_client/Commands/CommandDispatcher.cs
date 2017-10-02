using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using chatapp_client.Handlers;

namespace chatapp_client.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(null == command) throw new ArgumentNullException();
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = componentContext.Resolve(handlerType);
            await handler.HandleAsync((dynamic)command);
        }
    }
}
