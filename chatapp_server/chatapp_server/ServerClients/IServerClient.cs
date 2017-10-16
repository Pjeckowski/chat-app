using chatapp_server.Users;

namespace chatapp_server.ServerClients
{
    public interface IServerClient
    {
        IUser User { get; set; }
        void DataSendAsync(string data);
    }
}
