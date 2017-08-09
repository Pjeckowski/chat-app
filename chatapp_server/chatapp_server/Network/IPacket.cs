using chatapp_server.Request;

namespace chatapp_server.Network
{
    public interface IPacket
    {
        RequestType Header { get; }
        string Body { get; }
        string RequestStart { get; }
        string RequestEnd { get; }
    }
}
