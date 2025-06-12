using Canducci.HubDev;
using DotNetEnv;
using System;
using System.IO;
namespace CslAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Env.Load();                
                string apiKey = Environment.GetEnvironmentVariable("HUB_DEV");
                //
                HubDev hubDev = new HubDev(apiKey);
                ZipSearch zipSearch = new ZipSearch(hubDev);
                CpfSearch cpfSearch = new CpfSearch(hubDev);
                CnpjSearch cnpjSearch = new CnpjSearch(hubDev);
                var result = zipSearch.Get("19200000");
                var result2 = cpfSearch.Get("26257821886", new DateTime(1990, 1, 1));
                var result3a = cnpjSearch.Get("09.645.389/0001-05", true);
                var result3 = cnpjSearch.Get("00776574000156", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
