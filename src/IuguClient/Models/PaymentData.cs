using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class PaymentData
    {
        [JsonConstructor]
        public PaymentData(string creditCardNumber, 
            string creditCardVerificationValue, 
            string firstName, 
            string lastName, 
            string month, 
            string year)
        {
            CreditCardNumber = creditCardNumber;
            CreditCardVerificationValue = creditCardVerificationValue;
            FirstName = firstName;
            LastName = lastName;
            Month = month;
            Year = year;
        }

        [JsonProperty("number")]
        public string CreditCardNumber { get; }
        [JsonProperty("verification_value")]
        public string CreditCardVerificationValue { get; }
        [JsonProperty("first_name")]
        public string FirstName { get; }
        [JsonProperty("last_name")]
        public string LastName { get; }
        [JsonProperty("month")]
        public string Month { get; }
        [JsonProperty("year_value")]
        public string Year { get; }
    }
}