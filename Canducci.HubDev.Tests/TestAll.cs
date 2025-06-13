namespace Canducci.HubDev.Tests
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

        [TestMethod]
        public void TestMethodCreateInstanceBalanceSearch()
        {
            HubDev hubDev = new HubDev("token");            
            BalanceSearch balanceSearch = new BalanceSearch(hubDev);
            Assert.IsNotNull(balanceSearch);            
            Assert.IsInstanceOfType<BalanceSearch>(balanceSearch);
        }

        [TestMethod]
        public void TestMethodCreateInstanceCnpjSearch()
        {
            HubDev hubDev = new HubDev("token");
            CnpjSearch cnpjSearch = new CnpjSearch(hubDev);
            Assert.IsNotNull(cnpjSearch);
            Assert.IsInstanceOfType<CnpjSearch>(cnpjSearch);
        }

        [TestMethod]
        public void TestMethodCreateInstanceCpfSearch()
        {
            HubDev hubDev = new HubDev("token");
            CpfSearch cpfSearch = new CpfSearch(hubDev);
            Assert.IsNotNull(cpfSearch);
            Assert.IsInstanceOfType<CpfSearch>(cpfSearch);
        }

        [TestMethod]
        public void TestMethodCreateInstanceZipSearch()
        {
            HubDev hubDev = new HubDev("token");
            ZipSearch zipSearch = new ZipSearch(hubDev);
            Assert.IsNotNull(zipSearch);
            Assert.IsInstanceOfType<ZipSearch>(zipSearch);
        }
    }
}
