using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serealization
{
    [TestFixture]
    public class ClientSerializationTest
    {
        [Test]
        public void SerializeClient()
        {
            var iuguClient = new IuguClient("email@email.com", "Cliente", "03318802379", null);
            var json = JsonConvert.SerializeObject(iuguClient);
            Assert.IsNotEmpty(json);
        }

        [Test]
        public void DeserializeClient()
        {
            var deserializeObject = JsonConvert.DeserializeObject<IuguClient>(JSON);
            Assert.IsNotNull(deserializeObject);
        }

        #region json

        private const string JSON = @"{
    ""id"": ""77C2565F6F064A26ABED4255894224F0"",
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
