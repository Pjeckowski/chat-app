using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//CQRS or command handler pathern
namespace chatapp_client.Handlers
{
    public class RegisterHandler : ICommandHandler<Register>
    {
        public Task HandleAsync(Register command)
        {
            Debug.WriteLine("Zadzialalo! " + command.Name + command.Password);
            return Task.Delay(20);
        }
    }
}
