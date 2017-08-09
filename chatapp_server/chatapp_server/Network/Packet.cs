using System;
using chatapp_server.Request;

namespace chatapp_server.Network
{
    public class Packet : IPacket
    {
        public Packet(string data)
        {
          // TODO: Implement gathering data
            if (!IsValid(data))
            {
                throw new ArgumentException();
            }
            var header = string.Empty;
            Header = EnumExtensions.GetValueFromDescription<RequestType>(header);
        }

        public RequestType Header { get; }
        public string Body { get; }
        public string RequestStart { get; }
        public string RequestEnd { get; }

        private bool IsValid(string data)
        {
            // TODO: Implement
            return false;
        }
    }
}
