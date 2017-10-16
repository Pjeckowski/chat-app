using System.Collections.Generic;
using chatapp_server.ServerClients;

namespace chatapp_server.ChatRoom
{ 
    /// <summary>
    /// Room object that ll probably manage all the users connected to the room with the messaging stuff
    /// </summary>
    public class ChatRoom : IChatRoom
    {
        /// <summary>
        /// Room Name property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Room ID property 
        /// </summary>

        public string Password { get; set; }

        /// <summary>
        /// List of Users that are actually connected to the room
        /// I dont know yet if it should be only user with id, or user's connections
        /// so class can manage all the chat messages stuff
        /// </summary>
        public List<IServerClient> ConnectedClients { get; private set; }

        public ChatRoom(string roomName)
        {
            this.Name = roomName;
            ConnectedClients = new List<IServerClient>();
        }

        /// <summary>
        /// Adds user connection to the room
        /// </summary>
        /// <param name="connectedUser"></param>
        public void AddClient(IServerClient serverClient)
        {
            if (ConnectedClients.Contains(serverClient))
            {
                // If user is trying to connect, but he already exists in this room it means there was some connection issue.
                // Server doesnt handle issues for now, neither has any heartbit checks, so it needs to be handled like this.
                ConnectedClients.Remove(serverClient);
                ConnectedClients.Add(serverClient);
                
            }
            else
            {
                ConnectedClients.Add(serverClient);
            }
        }


        public void RemoveClient(IServerClient serverClient)
        {
            if (ConnectedClients.Contains(serverClient))
                ConnectedClients.Remove(serverClient);
        }

        
    }
}
