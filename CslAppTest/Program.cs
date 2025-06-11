using Canducci.HubDev;

namespace CslAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HubDev hubDev = new HubDev("174162690UAtcQEhNFX314445456");
            ZipCode zipCode = new ZipCode(hubDev);
            var result = zipCode.GetAsync("01001000")
                .Result;
            var a = 10;
        }
    }
}
