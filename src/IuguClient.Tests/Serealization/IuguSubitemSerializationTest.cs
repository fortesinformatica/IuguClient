using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serealization
{
    [TestFixture]
    public class IuguSubitemSerializationTest
    {
        [Test]
        public void IuguSubitemSerialization()
        {
            var iuguSubitem = new IuguSubitem("1", "Item um", 1, 1000, true);
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented };
            var json = JsonConvert.SerializeObject(iuguSubitem);
            Assert.IsNotEmpty(json);
        }
    }
}
