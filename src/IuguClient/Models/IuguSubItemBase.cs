using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguSubItemBase
    {
        [JsonConstructor]
        public IuguSubItemBase(string id,
            string description,
            int quantity,
            int priceCents,
            string price)
        {
            Id = id;
            Description = description;
            Quantity = quantity;
            PriceCents = priceCents;
            Price = price;
        }

        public IuguSubItemBase(
            string description,
            int quantity,
            int priceCents)
        {
            Description = description;
            Quantity = quantity;
            PriceCents = priceCents;
        }

        [JsonProperty("id")]
        public string Id { get; }
        /// <summary>
        /// Descrição do Item
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }
        /// <summary>
        /// Quantidade
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; }
        /// <summary>
        /// Preço em Centavos. Valores negativos entram como desconto no total das Faturas criadas pela Assinatura
        /// </summary>
        [JsonProperty("price_cents")]
        public int PriceCents { get; }
        [JsonProperty("price")]
        public string Price { get; }
    }
}
