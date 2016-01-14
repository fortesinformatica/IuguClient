using NUnit.Framework;

namespace IuguClient.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var myMethod = Class1.MyMethod();
            // TODO: Add your test code here
            Assert.AreEqual("Teste", myMethod);
        }
    }
}
