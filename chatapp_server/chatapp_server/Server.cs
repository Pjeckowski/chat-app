using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    /// <summary>
    /// Main object that ll handle new connection requests, add users, create rooms, pass the UserConnections to the rooms,
    /// after user verification is complited and room have been chosen by the user
    /// </summary>
    class Server
    {
        public Server()
        {
            /*to do:
             * Load room's list,
             * Load user's list,
             * start server thread that ll wait for connections,
             * 
            */
        }

        /*to do:
         * server thread,
         * methods to handle:
         *      adding new users,
         *      adding new room,
         *      initial client connection stuff (user verification, or adding new one, choosing a room etc) OR maybe should I make some
         *      mediate class between Server and ChatRoom?
         * 
         */
    }
}
