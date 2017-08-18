

using chatapp_server;

namespace chatapp_server
{
    public interface IPacket
    {
        PacketType Header { get; }
        string Body { get; }
    }
}
