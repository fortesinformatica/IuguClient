using System;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguLog
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}