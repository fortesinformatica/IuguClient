using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguInvoice
    {
        [JsonConstructor]
        public IuguInvoice(string id,
            string email,
            DateTime dueDate,
            IEnumerable<IuguInvoiceItem> items,
            string expiredUrl,
            string notificationUrl,
            int? taxCents,
            bool? fines,
            decimal? latePaymentFine,
            bool? perDayInterest,
            int? discountCents,
            string customerId,
            bool? ignoreDueEmail,
            string subscriptionId,
            PaymentOptions payableWith,
            int? credits,
            IEnumerable<IuguLog> logs,
            IDictionary<string, string> customVariable)
        {
            Id = id;
            DueDate = dueDate;
            Items = items;
            ExpiredUrl = expiredUrl;
            NotificationUrl = notificationUrl;
            TaxCents = taxCents;
            Fines = fines;
            LatePaymentFine = latePaymentFine;
            PerDayInterest = perDayInterest;
            DiscountCents = discountCents;
            CustomerId = customerId;
            IgnoreDueEmail = ignoreDueEmail;
            SubscriptionId = subscriptionId;
            PayableWith = payableWith;
            Credits = credits;
            Email = email;
            Logs = logs;
            CustomVariables = customVariable;
        }

        public IuguInvoice(string email,
                    DateTime dueDate,
                    IEnumerable<IuguInvoiceItem> items,
                    string expiredUrl = null,
                    string notificationUrl = null,
                    int? taxCents = null,
                    bool? fines = null,
                    decimal? latePaymentFine = null,
                    bool? perDayInterest = null,
                    int? discountCents = null,
                    string customerId = null,
                    bool? ignoreDueEmail = null,
                    string subscriptionId = null,
                    PaymentOptions? payableWith = null,
                    int? credits = null,
                    IEnumerable<IuguLog> logs = null,
                    IDictionary<string, string> customVariable = null)
        {
            Email = email;
            DueDate = dueDate;
            Items = items;
            ExpiredUrl = expiredUrl;
            NotificationUrl = notificationUrl;
            TaxCents = taxCents;
            Fines = fines;
            LatePaymentFine = latePaymentFine;
            PerDayInterest = perDayInterest;
            DiscountCents = discountCents;
            CustomerId = customerId;
            IgnoreDueEmail = ignoreDueEmail;
            SubscriptionId = subscriptionId;
            PayableWith = payableWith;
            Credits = credits;
            Email = email;
            Logs = logs;
            CustomVariables = customVariable;
        }

        [JsonProperty("id")]
        public string Id { get; }
        [JsonProperty("due_date")]
        public DateTime DueDate { get; }
        [JsonProperty("items")]
        public IEnumerable<IuguInvoiceItem> Items { get; set; }
        [JsonProperty("email")]
        public string Email { get; }
        [JsonProperty("expired_url")]
        public string ExpiredUrl { get; }
        [JsonProperty("notification_url")]
        public string NotificationUrl { get; }
        [JsonProperty("tax_cents")]
        public int? TaxCents { get; }
        [JsonProperty("fines")]
        public bool? Fines { get; }
        [JsonProperty("late_payment_fine")]
        public decimal? LatePaymentFine { get; }
        [JsonProperty("per_day_interest")]
        public bool? PerDayInterest { get; }
        [JsonProperty("discount_cents")]
        public int? DiscountCents { get; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; }
        [JsonProperty("ignore_due_email")]
        public bool? IgnoreDueEmail { get; }
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; }
        [JsonProperty("payable_with")]
        public PaymentOptions? PayableWith { get; }
        [JsonProperty("credits")]
        public int? Credits { get; }
        [JsonProperty("logs")]
        public IEnumerable<IuguLog> Logs { get; set; }
        [JsonProperty("custom_variables")]
        public IDictionary<string, string> CustomVariables { get; set; }
    }
}