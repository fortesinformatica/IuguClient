using System.Configuration;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Configuration
{
    [TestFixture]
    public class IuguApiClientTest
    {
        [Test]
        public void WhenCreatingIuguApiClientIfThereIsNoIuguApiTokenInAppSettingShouldThrowException()
        {
            var value = ConfigurationManager.AppSettings.Get("IuguApiToken");
            ConfigurationManager.AppSettings.Set("IuguApiToken", null);
            var configurationErrorsException = Assert.Throws<ConfigurationErrorsException>(() => new IuguApiClient());
            Assert.AreEqual("IuguApiToken não está configurado no App.config ou Web.config", configurationErrorsException.Message);
            ConfigurationManager.AppSettings.Set("IuguApiToken", value);
        }
    }
}
