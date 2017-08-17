

using chatapp_server.Network;

namespace chatapp_server
{
    public interface IPacket
    {
        PacketType Header { get; }
        string Body { get; }
    }
}
