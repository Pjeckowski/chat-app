using System;

namespace chatapp_client.Serializer
{
    public interface ISerializer
    {
        string Serialize (Object obj);
        Object Deserialize(string jsonData);
    }
}
