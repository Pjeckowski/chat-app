using System;

namespace chatapp_server.Network
{
    public class Packet : IPacket
    {
        public PacketType Header { get; private set; }
        public string Body { get; private set; }

        public static char START_SIGN = (char)(1);
        public static char END_SIGN = (char)(2);
        
        public Packet(string data)
        {
            if (!IsValid(data))
            {
                throw new ArgumentException();
            }
            var header = GetHeader(data);
            Header = EnumExtensions.GetValueFromDescription<PacketType>(header);
            Body = GetBody(data, header);
        }

        // TODO: More intelligent validation
        // Considering aspects that we have spoke about there is no other option to validate packet other, than checking the
        // header.
        private bool IsValid(string data)
        {
            if(data.Length >= 2)
            {
                return true;
            }
            return false;
        }

        private string GetHeader(string data)
        {
            return data.Substring(0, 1);
        }

        private string GetBody(string data, string header)
        {
            int bodystartindex = header.Length;
            int bodylength = data.Length - bodystartindex;

            return data.Substring(bodystartindex, bodylength);
        }
    }
}
