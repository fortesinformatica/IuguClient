using System;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguPrice
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("value_cents")]
        public int ValueCents { get; set; }
    }
}