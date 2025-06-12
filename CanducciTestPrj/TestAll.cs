using Canducci.HubDev;
namespace CanducciTestPrj
{
    [TestClass]
    public sealed class TestAll
    {
        [TestMethod]
        public void TestMethodCreateInstanceHuvDev()
        {
            HubDev hubDev = new HubDev("token");
            Assert.IsNotNull(hubDev);
            Assert.AreEqual("token", hubDev.Token);
            Assert.IsInstanceOfType<HubDev>(hubDev);
        }
    }
}
