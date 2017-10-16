using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Documents;
using Autofac;
using chatapp_server.CommandBus;
using chatapp_server.Serializer;
using chatapp_server.Users;
using chatapp_server.ServerClients;


namespace chatapp_server.Servers
{
    /// <summary>
    /// Main object that ll handle new connection requests, add users, create rooms, pass the UserConnections to the rooms,
    /// after user verification is complited and room have been chosen by the user
    /// </summary>
    public class Server : IServer
    {
        private TcpListener ServerSocket;
        private IComponentContext ComponentContext;
        private List<IServerClient> ServerClients = new List<IServerClient>();
 
        public bool Connected {get { return null != ServerSocket && ServerSocket.Server.Connected; } }
 
        public Server(IComponentContext componentContext)
        {
            ComponentContext = componentContext;
        }

         public bool ServerStart()
         {
             ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"),36000);
             //ChatRoomList.Add(new ChatRoom("Default", 1));

             ServerSocket.Start();
             Accept();
             return Connected;
         }

        private async void Accept()
        {
            while (true)
            { 
                IServerClient client = new ServerClient(await ServerSocket.AcceptTcpClientAsync(), ComponentContext.Resolve<ISerializer>(), ComponentContext.Resolve<ICommandBus>());
                ServerClients.Add(client);
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


