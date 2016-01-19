using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguFeatures
    {
        [JsonProperty("feat")]
        public IuguFeature IuguFeature { get; set; }
    }
}