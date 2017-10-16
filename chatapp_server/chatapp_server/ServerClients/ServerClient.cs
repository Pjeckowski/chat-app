using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using chatapp_server.CommandBus;
using chatapp_server.Serializer;
using chatapp_server.Users;
using Chat_Protocol.Commands;

namespace chatapp_server.ServerClients
{
    public class ServerClient : IServerClient
    {
        public IUser User { get; set; }

        private ISerializer Serializer;
        //public delegate void EventDelegate(string message, User connectedUser);
        //public event EventDelegate MessageReceived;
        public TcpClient TcpClient { get; private set; }

        private readonly ICommandBus commandBus;

        public ServerClient(TcpClient tcpClient, ISerializer serializer, ICommandBus commandBus)
        {
            TcpClient = tcpClient;
            Serializer = serializer;
            this.commandBus = commandBus;
            DataReceiveAsync();
        }

        private async void DataReceiveAsync()
        {
            while (TcpClient.Connected)
            {
                var buffer = new byte[TcpClient.ReceiveBufferSize];
                var bytesRead = await TcpClient.GetStream().ReadAsync(buffer, 0, TcpClient.ReceiveBufferSize);
                Array.Resize(ref buffer, bytesRead);
                var stringBuffer = Encoding.ASCII.GetString(buffer);

                if (null != stringBuffer)
                {
                    ICommand command = (ICommand) Serializer.Deserialize(stringBuffer);
                    await commandBus.Send(command);
                    Debug.WriteLine(command.ToString());
                }
            }
        }

        public async void DataSendAsync(string data)
        {
            await Task.Delay(500);
        }

    }
}
