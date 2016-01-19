using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguSubscription
    {
        public IuguSubscription(string customerId, string planIdentifier = null, DateTime? expiresAt = null, bool? onlyOnChargeSuccess = null, PaymentOptions? payableWith = null, int? priceCents = null, decimal? creditsCycle = null, int? creditsMin = null, IEnumerable<IuguSubitem> subitems = null, object[] customVariables = null)
        {
            CustomerId = customerId;
            PlanIdentifier = planIdentifier;
            ExpiresAt = expiresAt;
            OnlyOnChargeSuccess = onlyOnChargeSuccess;
            PayableWith = payableWith;
            PriceCents = priceCents;
            CreditsCycle = creditsCycle;
            CreditsMin = creditsMin;
            Subitems = subitems;
            CustomVariables = customVariables;
        }

        [JsonConstructor]
        public IuguSubscription(string id, bool suspended, string planIdentifier, bool? onlyOnChargeSuccess, PaymentOptions? payableWith, int? priceCents, string currency, IuguFeatures iuguFeatures, DateTime? expiresAt, DateTime createdAt, DateTime updatedAt, string customerName, string customerEmail, DateTime? cycledAt, int? creditsMin, decimal? creditsCycle, string customerId, string planName, string customerRef, string planRef, bool active, object inTrial, int credits, bool? creditsBased, object recentInvoices, IEnumerable<IuguSubitem> subitems, IEnumerable<IuguLog> logs, object[] customVariables)
        {
            Id = id;
            Suspended = suspended;
            PlanIdentifier = planIdentifier;
            OnlyOnChargeSuccess = onlyOnChargeSuccess;
            PayableWith = payableWith;
            PriceCents = priceCents;
            Currency = currency;
            IuguFeatures = iuguFeatures;
            ExpiresAt = expiresAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CycledAt = cycledAt;
            CreditsMin = creditsMin;
            CreditsCycle = creditsCycle;
            CustomerId = customerId;
            PlanName = planName;
            CustomerRef = customerRef;
            PlanRef = planRef;
            Active = active;
            InTrial = inTrial;
            Credits = credits;
            CreditsBased = creditsBased;
            RecentInvoices = recentInvoices;
            Subitems = subitems;
            Logs = logs;
            CustomVariables = customVariables;
        }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("suspended")]
        public bool Suspended { get; set; }
        /// <summary>
        /// Identificador do Plano. Só é enviado para assinaturas que não são credits_based
        /// </summary>
        [JsonProperty("plan_identifier")]
        public string PlanIdentifier { get; set; }
        /// <summary>
        /// Apenas Cria a Assinatura se a Cobrança for bem sucedida. Isso só funciona caso o cliente já tenha uma forma de pagamento padrão cadastrada
        /// </summary>
        [JsonProperty("only_on_charge_success")]
        public bool? OnlyOnChargeSuccess { get; set; }
        /// <summary>
        /// Método de pagamento que será disponibilizado para as Faturas desta Assinatura (all, credit_card ou bank_slip). 
        /// Obs: Dependendo do valor, este atributo será herdado, pois a prioridade é herdar o valor atribuído ao Plano desta Assinatura; caso este esteja atribuído o valor ‘all’, o sistema considerará o payable_with da Assinatura; se não, o sistema considerará o payable_with do Plano
        /// </summary>
        [JsonProperty("payable_with")]
        public PaymentOptions? PayableWith { get; set; }
        /// <summary>
        /// Preço em centavos da recarga para assinaturas baseadas em crédito
        /// </summary>
        [JsonProperty("price_cents")]
        public int? PriceCents { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("features")]
        public IuguFeatures IuguFeatures { get; set; }
        /// <summary>
        /// Data de Expiração (Também é a data da próxima cobrança)
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }
        [JsonProperty("cycled_at")]
        public DateTime? CycledAt { get; set; }
        /// <summary>
        /// Quantidade de créditos que ativa o ciclo
        /// Exemplo: Efetuar cobrança cada vez que a assinatura tenha apenas 1 crédito sobrando. Esse 1 crédito é o credits_min
        /// </summary>
        [JsonProperty("credits_min")]
        public int? CreditsMin { get; set; }
        /// <summary>
        /// Quantidade de créditos adicionados a cada ciclo, só enviado para assinaturas credits_based
        /// </summary>
        [JsonProperty("credits_cycle")]
        public decimal? CreditsCycle { get; set; }
        /// <summary>
        /// ID do Cliente
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("plan_name")]
        public string PlanName { get; set; }
        [JsonProperty("customer_ref")]
        public string CustomerRef { get; set; }
        [JsonProperty("plan_ref")]
        public string PlanRef { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("in_trial")]
        public object InTrial { get; set; }
        [JsonProperty("credits")]
        public int Credits { get; set; }

        /// <summary>
        /// É uma assinatura baseada em créditos? 
        /// </summary>
        [JsonProperty("credits_based")]
        public bool? CreditsBased { get; set; }
        [JsonProperty("recent_invoices")]
        public object RecentInvoices { get; set; }
        /// <summary>
        /// Array com Itens de Assinatura, sendo que estes podem ser recorrentes ou de cobrança única
        /// </summary>
        [JsonProperty("subitems")]
        public IEnumerable<IuguSubitem> Subitems { get; set; }
        [JsonProperty("logs")]
        public IEnumerable<IuguLog> Logs { get; set; }
        [JsonProperty("custom_variables")]
        public object[] CustomVariables { get; set; }
    }
}