namespace IuguClientAPI.Models
{
    public class PaymentData
    {
        public PaymentData(string creditCardNumber, string creditCardVerificationValue, string firstName, string lastName, string month, string year)
        {
            CreditCardNumber = creditCardNumber;
            CreditCardVerificationValue = creditCardVerificationValue;
            FirstName = firstName;
            LastName = lastName;
            Month = month;
            Year = year;
        }

        public string CreditCardNumber { get; }
        public string CreditCardVerificationValue { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Month { get; }
        public string Year { get; }
    }
}