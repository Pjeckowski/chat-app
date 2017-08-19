

namespace chatapp_server.Network
{
    public interface IPacket
    {
        PacketType Header { get; }
        string Body { get; }
    }
}
