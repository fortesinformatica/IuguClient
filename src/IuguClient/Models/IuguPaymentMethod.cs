using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguPaymentMethod
    {
        [JsonConstructor]
        public IuguPaymentMethod(string id,
            string customerId, 
            string description,
            PaymentData data,
            PaymentOptions? itemType,
            string token, 
            bool setAsDefault = false)
        {
            Id = id;
            CustomerId = customerId;
            Description = description;
            ItemType = itemType;
            SetAsDefault = setAsDefault;
            Token = token;
            Data = data;
        }

        /// <summary>
        /// Cria uma forma de pagamento com Token
        /// </summary>
        /// <param name="customerId">Id do Cliente</param>
        /// <param name="description">Descrição</param>
        /// <param name="data">Dados da Forma de Pagamento</param>
        /// <param name="token">Token de Pagamento</param>
        /// <param name="setAsDefault">Define esta Forma de Pagamento como padrão do Cliente</param>
        public IuguPaymentMethod(string customerId, 
            string description,
            PaymentData data,
            string token, 
            bool? setAsDefault)
        {
            CustomerId = customerId;
            Description = description;
            SetAsDefault = setAsDefault;
            Token = token;
            Data = data;
        }

        /// <summary>
        /// Cria uma forma de pagamento sem token.
        /// </summary>
        /// <param name="customerId">Id do Cliente</param>
        /// <param name="description">Descrição</param>
        /// <param name="data">Dados da Forma de Pagamento</param>
        /// <param name="itemType">Tipo da Forma de Pagamento</param>
        /// <param name="setAsDefault">Define esta Forma de Pagamento como padrão do Cliente</param>
        public IuguPaymentMethod(string customerId, 
            string description, 
            PaymentData data,
            PaymentOptions itemType,
            bool? setAsDefault)
        {
            CustomerId = customerId;
            Description = description;
            ItemType = itemType;
            SetAsDefault = setAsDefault;
            Data = data;
        }

        [JsonProperty("id")]
        public string Id { get; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; }
        [JsonProperty("description")]
        public string Description { get; }
        [JsonProperty("item_type")]
        public PaymentOptions? ItemType { get; }
        [JsonProperty("token")]
        public string Token { get; }
        [JsonProperty("data")]
        public PaymentData Data { get; }
        [JsonProperty("set_as_default")]
        public bool? SetAsDefault { get; set; }
    }
}
