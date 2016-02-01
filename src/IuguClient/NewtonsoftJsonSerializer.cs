using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace IuguClientAPI
{
    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        public static NewtonsoftJsonSerializer Instance { get; } = new NewtonsoftJsonSerializer();

        private NewtonsoftJsonSerializer() { }

        public string ContentType { get; set; } = "application/json";

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj) => JsonConvert.SerializeObject(obj);

        public T Deserialize<T>(IRestResponse response) => JsonConvert.DeserializeObject<T>(response.Content);
    }
}
