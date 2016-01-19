using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguSubitem
    {
        public IuguSubitem(string id, string description, int quantity, int priceCents, bool? recurrent)
        {
            Id = id;
            Description = description;
            Quantity = quantity;
            PriceCents = priceCents;
            Recurrent = recurrent;
        }

        [JsonConstructor]
        public IuguSubitem(string id, string description, int quantity, int priceCents, bool? recurrent, string price, string total)
        {
            Id = id;
            Description = description;
            Quantity = quantity;
            PriceCents = priceCents;
            Recurrent = recurrent;
            Price = price;
            Total = total;
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
        /// <summary>
        /// Item recorrente?
        /// </summary>
        [JsonProperty("recurrent")]
        public bool? Recurrent { get; }
        [JsonProperty("price")]
        public string Price { get; }
        [JsonProperty("total")]
        public string Total { get; }
    }
}