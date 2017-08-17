using System;


namespace chatapp_server
{
    public class Packet : IPacket
    {
        // TODO: Replace with Packet Type
        public RequestType Header { get; private set; }
        public string Body { get; private set; }

        public static string START_SIGN = "*";
        public static string END_SIGN = "#";
        
        public Packet(string data)
        {
            if (!IsValid(data))
            {
                throw new ArgumentException();
            }
            //var header = GetHeader(data);
            //Header = EnumExtensions.GetValueFromDescription<RequestType>(header);
            //Body = GetBody(data, header);
        }

        // TODO: More intelligent validation
        private bool IsValid(string data)
        {
            return !string.IsNullOrEmpty(data);
        }

        //private string GetHeader(string data)
        //{
        //    return data.Substring(RequestStart.Length, 1);
        //}

        //private string GetBody(string data, string header)
        //{
        //    int bodystartindex = RequestStart.Length + header.Length;
        //    int bodylength = data.Length - bodystartindex - RequestEnd.Length;

        //    return data.Substring(bodystartindex, bodylength);
        //}
    }
}
