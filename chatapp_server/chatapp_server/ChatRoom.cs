using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{ 
    /// <summary>
    /// Room object that ll probably manage all the users connected to the room with the messaging stuff
    /// </summary>
    public class ChatRoom
    {
        /// <summary>
        /// Room Name property
        /// </summary>
        public string RoomName { get; private set; }
        /// <summary>
        /// Room ID property 
        /// </summary>
        public uint RoomID { get; private set; }

        /// <summary>
        /// List of Users that are actually connected to the room
        /// I dont know yet if it should be only user with id, or user's connections
        /// so class can manage all the chat messages stuff
        /// </summary>
        public List<UserConnection> ConnectedUsers { get; private set; }

        public ChatRoom(string RoomName, uint RoomID)
        {
            this.RoomName = RoomName;
            this.RoomID = RoomID;
            ConnectedUsers = new List<UserConnection>();
        }

        /// <summary>
        /// Adds user connection to the room
        /// </summary>
        /// <param name="ConnectedUser"></param>
        public void AddUser(UserConnection ConnectedUser)
        {
            if (ConnectedUsers.Contains(ConnectedUser))
            {
                // If user is trying to connect, but he already exists in this room it means there was some connection issue.
                // Server doesnt handle issues for now, neither has any heartbit checks, so it needs to be handled like this.
                ConnectedUsers.Remove(ConnectedUser);
                ConnectedUsers.Add(ConnectedUser);
                ConnectedUser.MessageReceived += ConnectedUser_MessageReceived;
            }
            else
            {
                ConnectedUsers.Add(ConnectedUser);
                ConnectedUser.MessageReceived += ConnectedUser_MessageReceived;
            }
        }

        private void ConnectedUser_MessageReceived(string message, UserConnection ConnectedUser)
        {
            foreach (UserConnection UC in ConnectedUsers)
            {
                if(!(ConnectedUser.Equals(UC)))
                {
                    UC.SendMessage(message);
                }
            }
        }



        public void RemoveUser(UserConnection ConnectedUser)
        {
            if (ConnectedUsers.Contains(ConnectedUser))
                ConnectedUsers.Remove(ConnectedUser);
        }

        
    }
}
