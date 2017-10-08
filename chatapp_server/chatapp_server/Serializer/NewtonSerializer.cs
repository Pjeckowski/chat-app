using System;
using Newtonsoft.Json;

namespace chatapp_server.Serializer
{
    public class NewtonSerializer :ISerializer
    {
        private readonly JsonSerializerSettings JsonSettings;
        
        public NewtonSerializer()
        {
            JsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }
        public string Serialize(Object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSettings);
        }

        public Object Deserialize(string jsonData)
        {
            return JsonConvert.DeserializeObject<Object>(jsonData, JsonSettings);
        }
    }
}
