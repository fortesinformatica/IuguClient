using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serialization
{
    [SetUpFixture]
    public class BaseTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented };
        }
    }
}