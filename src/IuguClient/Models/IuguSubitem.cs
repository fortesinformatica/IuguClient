using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguSubitem : IuguSubItemBase
    {
        public IuguSubitem(string description, int quantity, int priceCents, bool? recurrent)
            : base(description, quantity, priceCents)
        {
            Recurrent = recurrent;
        }

        [JsonConstructor]
        public IuguSubitem(string id, string description, int quantity, int priceCents, bool? recurrent, string price, string total)
            : base(id, description, quantity, priceCents, price)
        {
            Recurrent = recurrent;
            Total = total;
        }

        /// <summary>
        /// Item recorrente?
        /// </summary>
        [JsonProperty("recurrent")]
        public bool? Recurrent { get; }
        [JsonProperty("total")]
        public string Total { get; }
    }
}