
namespace Chat_Protocol.Commands
{
    public class MessageCommand : ICommand
    {
        public string Message { get; private set; }

        public MessageCommand(string message)
        {
            Message = message;
        }
    }
}
