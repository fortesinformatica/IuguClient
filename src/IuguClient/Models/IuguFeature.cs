using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguFeature
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}