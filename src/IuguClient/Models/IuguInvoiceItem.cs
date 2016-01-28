using System;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguInvoiceItem : IuguSubItemBase
    {
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonConstructor]
        public IuguInvoiceItem(string id, string description, int quantity, int priceCents, string price,
            DateTime createdAt, DateTime? updatedAt)
            : base(id, description, quantity, priceCents, price)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public IuguInvoiceItem(string description, int quantity, int priceCents)
            : base(description, quantity, priceCents)
        { }
    }
}