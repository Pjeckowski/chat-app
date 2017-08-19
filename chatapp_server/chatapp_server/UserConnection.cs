using System.Net.Sockets;
using chatapp_server.Users;


namespace chatapp_server
{
    /// <summary>
    /// Object that is going to be made in Server class.
    /// Its going to contain user, thats its made for,
    /// user's connection stuff, and methods to handle sending and receiving.
    /// </summary>
    public class UserConnection
    {
       
        public delegate void EventDelegate(string message, UserConnection connectedUser);
        public event EventDelegate MessageReceived;
        /// <summary>
        /// Event triggered, when message is received from client
        /// </summary>
        


        public IUser User { get; private set; }
        public TcpClient ClientSocket { get; private set; }

        /// <summary>
        /// Sends message to a client
        /// </summary>
        /// <param name="message"></param>
        /// 

        public UserConnection(TcpClient clientSocket, IUser user)
        {
            User = user;
            ClientSocket = clientSocket;
        }

        public void SendMessage(string message)
        { 
        }
        
    }
}
