using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chatapp_server.ServerClients;

namespace chatapp_server.ChatRoom
{
    public interface IChatRoom
    {
        /// <summary>
        /// Room Name property
        /// </summary>
        string Name { get; set; }

        string Password { get; set; }

        /// <summary>
        /// List of Users that are actually connected to the room
        /// I dont know yet if it should be only user with id, or user's connections
        /// so class can manage all the chat messages stuff
        /// </summary>
        List<IServerClient> ConnectedClients { get;}

        void AddClient(IServerClient serverClient);

        void RemoveClient(IServerClient serverClient);
    }
}
