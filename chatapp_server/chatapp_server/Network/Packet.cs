using System;


namespace chatapp_server
{
    public class Packet : IPacket
    {
        public User CallingUser { get; private set; }
        public RequestType Header { get; private set; }
        public string Body { get; private set; }

        private string RequestStart = "*";
        private string RequestEnd = "#";
        
        public Packet(User CallingUser, string data)
        {
          // TODO: Implement gathering data         done??
            if (!IsValid(data))
            {
                throw new ArgumentException();
            }
            var header = GetHeader(data);

            try
            {
                Header = EnumExtensions.GetValueFromDescription<RequestType>(header);
            }
            catch ( InvalidOperationException )
            {
                throw new ArgumentException();
            }

            Body = GetBody(data, header);

            this.CallingUser = CallingUser;
            
        }

        private bool IsValid(string data)
        {
            if (string.Empty != data && null != data)
            {
                if (data.Length > RequestStart.Length + RequestEnd.Length)
                {
                    if (data.StartsWith(RequestStart) && data.EndsWith(RequestEnd))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string GetHeader(string data)
        {
            return data.Substring(RequestStart.Length, 1);
        }

        private string GetBody(string data, string header)
        {
            int bodystartindex = RequestStart.Length + header.Length;
            int bodylength = data.Length - bodystartindex - RequestEnd.Length;

            return data.Substring(bodystartindex, bodylength);
        }
    }
}
