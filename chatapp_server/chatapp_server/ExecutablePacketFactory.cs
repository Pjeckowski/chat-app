using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    public abstract class ExecutablePacketFactory
    {
        public static RequestFactory GetFactory(IPacket Packet)
        {
            switch (Packet.Header)
            {
                case PacketType.REQUEST:
                    {
                        return new RequestFactory();
                    }
                case PacketType.RESPONSE:
                    {
                        return new ResponseFactory();
                    }
            }
        }
    }
}
