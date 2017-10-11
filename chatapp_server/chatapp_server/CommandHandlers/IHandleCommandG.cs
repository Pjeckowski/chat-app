using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chatapp_server.Commands;

namespace chatapp_server.CommandHandlers
{
    public interface IHandleCommandG<TCommand> : IHandleCommand where TCommand: ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
