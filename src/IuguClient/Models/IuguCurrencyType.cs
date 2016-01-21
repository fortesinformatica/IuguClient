using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IuguClientAPI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IuguCurrencyType
    {
        BRL
    }
}