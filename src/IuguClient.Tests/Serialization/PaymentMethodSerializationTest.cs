using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serialization
{
    [TestFixture]
    public class PaymentMethodSerializationTest : BaseTestSetup
    {
        public static IuguPaymentMethod IuguPaymentMethod => JsonConvert.DeserializeObject<IuguPaymentMethod>(JSON);

        [Test]
        public void SerializeClient()
        {
            var paymentData = new PaymentData("4111111111111111", "123", "Joao", "Silva", "12", "2013");
            var iuguClient = new IuguPaymentMethod("2", "Meu Cartão de Crédito", paymentData, PaymentOptions.credit_card, null);
            var json = JsonConvert.SerializeObject(iuguClient);
            Assert.IsNotEmpty(json);
        }

        [Test]
        public void DeserializeClient() => Assert.IsNotNull(IuguPaymentMethod);


        private const string JSON = @"{
            ""id"": ""9B41FB19CBA44913B1EF990A10382E7E"",
            ""description"": ""Meu Cartão de Crédito"",
            ""item_type"": ""credit_card"",
            ""data"": {
                ""token"": ""82ca2b4a-2302-4bb5-a372-c399cc3ae324-9ln362492t145hijkv7pvgi4lw39if4o"",
                ""display_number"": ""XXXX-XXXX-XXXX-1111"",
                ""brand"": ""visa""
            }
        }";
    }
}
