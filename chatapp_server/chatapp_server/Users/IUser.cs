using System.Net.Sockets;

namespace chatapp_server.Users
{
    public interface IUser
    {
        uint ID { get; }
        string Nickname { get; }
        string Email { get; }
        string Password { get; }
    }
}
