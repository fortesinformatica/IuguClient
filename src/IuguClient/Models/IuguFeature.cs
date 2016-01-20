using System;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguFeature
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        [JsonProperty("important")]
        public object Important { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}