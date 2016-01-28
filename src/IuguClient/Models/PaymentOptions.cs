using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IuguClientAPI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentOptions
    {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "credit_card")]
        CreditCard,
        [EnumMember(Value = "bank_slip")]
        BankSlip
    }
}