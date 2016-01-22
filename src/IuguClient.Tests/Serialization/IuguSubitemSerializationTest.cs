using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serialization
{
    [TestFixture]
    public class IuguSubitemSerializationTest
    {
        [Test]
        public void IuguSubitemSerialization()
        {
            var iuguSubitem = new IuguSubitem("Item um", 1, 1000, true);
            var json = JsonConvert.SerializeObject(iuguSubitem);
            Assert.IsNotEmpty(json);
        }
    }
}
