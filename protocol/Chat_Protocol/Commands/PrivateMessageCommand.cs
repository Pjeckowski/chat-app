
namespace Chat_Protocol.Commands
{
    public class PrivateMessageCommand : ICommand
    {
        public string TargetUserName { get; private set; }
        public string Message { get; private set; }
    }
}
