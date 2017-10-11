using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using chatapp_server.Serializer;
using chatapp_server.Users;


namespace chatapp_server
{
    /// <summary>
    /// Main object that ll handle new connection requests, add users, create rooms, pass the UserConnections to the rooms,
    /// after user verification is complited and room have been chosen by the user
    /// </summary>
    public class Server
    {
        private TcpListener ServerSocket;
        private Thread ServerThread;


 
        public bool Connected {get { return null != ServerSocket && ServerSocket.Server.Connected; } }
 
        public Server()
        {
            

        }

         public bool ServerStart()
         {
             ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"),36000);
             //ChatRoomList.Add(new ChatRoom("Default", 1));

             return Connected;
         }

        private async void Accept()
        {
            while (Connected)
            { 
                var user = new ServerClient.ServerClient(await ServerSocket.AcceptTcpClientAsync(),new NewtonSerializer());
               // user.MessageReceived += onMessageReceived;
            }
        }

        void onMessageReceived(string message, User connectedUser)
        {
            
            throw new System.NotImplementedException();
        }



         //void ServerThreadM()
         //{
         //    ServerSocket.Start();
         //    while (Connected)
         //    {

         //        TcpClient NewClient = ServerSocket.AcceptTcpClient();
         //        UserConnection UserConnection = new UserConnection(NewClient, new User.User(1, "NewUser", "", ""));
         //        Thread.Sleep(100);
         //        Debug.WriteLine("Makapaka");
         //    }
         //}

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


