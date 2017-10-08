using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server.Serializer
{
    public interface ISerializer
    {
        string Serialize (Object obj);
        Object Deserialize(string jsonData);
    }
}
