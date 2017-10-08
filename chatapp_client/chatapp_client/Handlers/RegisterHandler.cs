using System.Diagnostics;
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
