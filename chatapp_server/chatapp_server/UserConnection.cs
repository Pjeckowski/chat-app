using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public User User { get; private set; }

        /// <summary>
        /// Sends message to a client
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        { 
        }
        
    }
}
