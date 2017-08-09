using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using chatapp_server.Network;

namespace chatapp_server
{
    /// <summary>
    /// Main object that ll handle new connection requests, add users, create rooms, pass the UserConnections to the rooms,
    /// after user verification is complited and room have been chosen by the user
    /// </summary>
    class Server
    {
        private TcpListener ServerSocket;
        private Thread ServerThread;

        public List<ChatRoom> ChatRoomList { get; private set; }
        public bool ServerStatus { get; private set; }
 
        public Server()
        {
            ChatRoomList = new List<ChatRoom>();
          
        }

         public bool ServerStart()
         {
             ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"),36000);
             ServerThread = new Thread(new ThreadStart(ServerThreadM));
             ChatRoomList.Add(new ChatRoom("Default", 1));
             ServerStatus = true;
             ServerThread.Start();
             return true;
         }

         void ServerThreadM()
         {
             ServerSocket.Start();
             while (ServerStatus)
             {

                 TcpClient NewClient = ServerSocket.AcceptTcpClient();
                 UserConnection UserConnection = new UserConnection(NewClient, new User(1, "NewUser", "", ""));
                 Thread.Sleep(100);
                 Debug.WriteLine("Makapaka");
             }
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
