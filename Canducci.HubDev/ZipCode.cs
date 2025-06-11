using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    public sealed class ZipCode
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;
        public ZipCode(HubDev hubDev)
        {
            _hubDev = hubDev;
        }
        public ZipCode(string token)
        {
            _hubDev = new HubDev(token);
        }
        public async Task<ZipCodeResponse> GetAsync(string zip)
        {
            string url = _urlAddress.GetUrlCEP(zip, _hubDev.Token);
            return await _httpClient.GetObjectAsync<ZipCodeResponse>(url);
        }
    }
}
