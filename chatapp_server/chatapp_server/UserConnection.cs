using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;


namespace chatapp_server
{
    /// <summary>
    /// Object that is going to be made in Server class.
    /// Its going to contain user, thats its made for,
    /// user's connection stuff, and methods to handle sending and receiving.
    /// </summary>
    class UserConnection
    {
       
        public delegate void EventDelegate(string message, UserConnection ConnectedUser);

        /// <summary>
        /// Event triggered, when message is received from client
        /// </summary>
        public event EventDelegate MessageReceived;


        public IUser User { get; private set; }
        public TcpClient ClientSocket { get; private set; }

        /// <summary>
        /// Sends message to a client
        /// </summary>
        /// <param name="message"></param>
        /// 

        public UserConnection(TcpClient ClientSocket, IUser User)
        {
            this.User = User;
            this.ClientSocket = ClientSocket;
        }

        public void SendMessage(string message)
        { 
        }
        
    }
}
