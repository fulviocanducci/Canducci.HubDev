using Canducci.HubDev;
using System;
namespace CslAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HubDev hubDev = new HubDev("174162690UAtcQEhNFX314445456");
                ZipSearch zipSearch = new ZipSearch(hubDev);
                CPFSearch cpfSearch = new CPFSearch(hubDev);
                CnpjSearch cnpjSearch = new CnpjSearch(hubDev);
                var result = zipSearch.GetAsync("01001111").Result;
                var result2 = cpfSearch.GetAsync("12345678900", new DateTime(1990, 1, 1)).Result;
                var result3a = cnpjSearch.GetAsync("09.645.389/0001-05", true).Result;
                var result3 = cnpjSearch.GetAsync("00776574000156", true).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
