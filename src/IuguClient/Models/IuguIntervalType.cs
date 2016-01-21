using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IuguClientAPI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IuguIntervalType
    {
        [EnumMember(Value = "weeks")]
        Weeks,
        [EnumMember(Value = "months")]
        Months
    }
}