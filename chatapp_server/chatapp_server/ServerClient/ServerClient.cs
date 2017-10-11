using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using chatapp_server.Commands;
using chatapp_server.Serializer;
using chatapp_server.Users;

namespace chatapp_server.ServerClient
{
    public class ServerClient : IServerClient
    {
        public IUser User { get; set; }

        private ISerializer Serializer;
        //public delegate void EventDelegate(string message, User connectedUser);
        //public event EventDelegate MessageReceived;
        public TcpClient TcpClient { get; private set; }

        public ServerClient(TcpClient tcpClient, ISerializer serializer)
        {
            TcpClient = tcpClient;
            Serializer = serializer;
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
