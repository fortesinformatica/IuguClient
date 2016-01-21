using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguPlan
    {
        /// <summary>
        ///     Cria um Plano.
        /// </summary>
        /// <param name="name">Nome do Plano</param>
        /// <param name="identifier">Identificador do Plano</param>
        /// <param name="interval">Ciclo do Plano (Número inteiro maior que 0)</param>
        /// <param name="intervalType">Tipo de Interval ("weeks" ou "months")</param>
        /// <param name="currency">Moeda do Preço (Somente "BRL" por enquanto)</param>
        /// <param name="valueCents">Preço do Plano em Centavos</param>
        /// <param name="payableWith">
        ///     Método de pagamento que será disponibilizado para as Faturas pertencentes a Assinaturas deste
        ///     Plano ('all', 'credit_card' ou 'bank_slip')
        /// </param>
        /// <param name="iuguPrices">Preços do Plano</param>
        /// <param name="features">Funcionalidades do Plano</param>
        public IuguPlan(string name, string identifier, int interval, IuguIntervalType intervalType,
                        IuguCurrencyType currency, int valueCents, PaymentOptions? payableWith = null,
                        IEnumerable<IuguPrice> iuguPrices = null, IEnumerable<IuguFeature> features = null)
        {
            Name = name;
            Identifier = identifier;
            Interval = interval;
            IntervalType = intervalType;
            Currency = currency;
            ValueCents = valueCents;
            PayableWith = payableWith;
            IuguPrices = iuguPrices;
            Features = features;
        }

        [JsonConstructor]
        public IuguPlan(string id, string name, string identifier, int interval, IuguIntervalType intervalType,
                        DateTime createdAt, DateTime updatedAt, IEnumerable<IuguPrice> iuguPrices,
                        IEnumerable<IuguFeature> features)
        {
            Id = id;
            Name = name;
            Identifier = identifier;
            Interval = interval;
            IntervalType = intervalType;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IuguPrices = iuguPrices;
            Features = features;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Nome do Plano
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Identificador do Plano
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Ciclo do Plano (Número inteiro maior que 0)
        /// </summary>
        [JsonProperty("interval")]
        public int Interval { get; set; }

        /// <summary>
        /// Tipo de Interval ("weeks" ou "months")
        /// </summary>
        [JsonProperty("interval_type")]
        public IuguIntervalType IntervalType { get; set; }

        /// <summary>
        /// Moeda do Preço (Somente "BRL" por enquanto)
        /// </summary>
        [JsonProperty("currency")]
        public IuguCurrencyType Currency { get; set; }

        /// <summary>
        /// Preço do Plano em Centavos
        /// </summary>
        [JsonProperty("value_cents")]
        public int ValueCents { get; set; }

        /// <summary>
        ///     Método de pagamento que será disponibilizado para as Faturas pertencentes a Assinaturas deste Plano ('all',
        ///     'credit_card' ou 'bank_slip')
        ///     Obs: Dependendo do valor, este atributo será herdado, pois a prioridade é herdar o valor atribuído ao Plano desta
        ///     Assinatura; caso este esteja atribuído o valor ‘all’, o sistema considerará o payable_with da Assinatura; se não, o
        ///     sistema considerará o payable_with do Plano
        /// </summary>
        [JsonProperty("payable_with")]
        public PaymentOptions? PayableWith { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("prices")]
        public IEnumerable<IuguPrice> IuguPrices { get; set; }

        [JsonProperty("features")]
        public IEnumerable<IuguFeature> Features { get; set; }
    }
}