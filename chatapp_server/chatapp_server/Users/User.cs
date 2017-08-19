using System;
using System.Net.Sockets;
using System.Text;
using chatapp_server.Network;

namespace chatapp_server.Users
{
    /// <summary>
    /// Object that ll contain User's ID, Nickname, Password, Email, Room penalties Etc.
    /// </summary>
    public class User : IUser
    {
        public delegate void EventDelegate(string message, User connectedUser);
        public event EventDelegate MessageReceived;

        public static readonly int BUFFER_SIZE = 1024; 

        public uint ID { get; private set; }

        public string Nickname { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public TcpClient TcpClient { get; private set; }

        public User(TcpClient tcpClient)
        {
            TcpClient = tcpClient;
        }

        private async void DataReceived()
        {  
            while(TcpClient.Connected)
            {
                var buffer = new byte[BUFFER_SIZE];
                var bytesRead = await TcpClient.GetStream().ReadAsync(buffer, 0, BUFFER_SIZE);
                Array.Resize(ref buffer, bytesRead);
                var stringBuffer = Encoding.ASCII.GetString(buffer);

                if (null != MessageReceived)
                {
                    MessageReceived(stringBuffer, this);
                }
            }
        }
        public virtual bool IsAdmin()
        {
            return false;
        }

        public void SendMessage(string message)
        {
        }
    }
}
