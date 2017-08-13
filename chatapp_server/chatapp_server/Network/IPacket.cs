

namespace chatapp_server
{
    public interface IPacket
    {
        RequestType Header { get; }
        string Body { get; }
        string RequestStart { get; }
        string RequestEnd { get; }
    }
}
