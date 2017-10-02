using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_client.Handlers
{
    public interface ICommandHandler <T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
