namespace IuguClientAPI.Models
{
    public class IuguPaymentMethod
    {
        public IuguPaymentMethod(string id, string description, string itemType, string token, PaymentData data)
        {
            Id = id;
            Description = description;
            ItemType = itemType;
            Token = token;
            Data = data;
        }

        public IuguPaymentMethod(string description, string itemType, string token, PaymentData data)
        {
            Description = description;
            ItemType = itemType;
            Token = token;
            Data = data;
        }

        public string Id { get; }
        public string Description { get; }
        public string ItemType { get; }
        public string Token { get; }
        public PaymentData Data { get; }
    }
}
