using NUnit.Framework;

namespace IuguClientAPI.Tests.Serialization
{
    [TestFixture]
    public class NewtonsoftJsonSerializerTest
    {
        [Test]
        public void TestMethod()
        {
            var jsonSerializer = NewtonsoftJsonSerializer.Instance;
            jsonSerializer.DateFormat = "dd/MM/yyyy";
            jsonSerializer.Namespace = "empty";
            jsonSerializer.RootElement = "empty";
            Assert.AreEqual("dd/MM/yyyy", jsonSerializer.DateFormat);
            Assert.AreEqual("empty", jsonSerializer.Namespace);
            Assert.AreEqual("empty", jsonSerializer.RootElement);
            Assert.AreEqual("application/json", jsonSerializer.ContentType);
        }
    }
}
