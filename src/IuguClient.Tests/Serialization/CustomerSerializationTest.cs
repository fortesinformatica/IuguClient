using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serialization
{
    [TestFixture]
    public class CustomerSerializationTest
    {
        public static IuguCustomer IuguCustomer => JsonConvert.DeserializeObject<IuguCustomer>(JSON);
        [Test]
        public void SerializeClient()
        {
            var iuguClient = new IuguCustomer("email@email.com", "Cliente", "03318802379", null);
            var json = JsonConvert.SerializeObject(iuguClient);
            Assert.IsNotEmpty(json);
        }

        [Test]
        public void DeserializeClient() => Assert.IsNotNull(IuguCustomer);

        #region json

        private const string JSON = @"{
    ""id"": ""1"",
    ""email"": ""email@email.com"",
    ""name"": ""Nome do Cliente"",
    ""notes"": ""Anotações Gerais"",
    ""created_at"": ""2013-11-18T14:58:30-02:00"",
    ""updated_at"": ""2013-11-18T14:58:30-02:00"",
    ""custom_variables"":[]
}";

        #endregion
    }
}
