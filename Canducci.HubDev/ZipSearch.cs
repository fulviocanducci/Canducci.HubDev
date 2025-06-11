using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    public sealed class ZipSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;
        public ZipSearch(HubDev hubDev)
        {
            _hubDev = hubDev;
        }
        public ZipSearch(string token)
        {
            _hubDev = new HubDev(token);
        }
        public async Task<ZipResponse> GetAsync(string zip)
        {
            string url = _urlAddress.GetUrlCEP(zip, _hubDev.Token);
            return await _httpClient.GetObjectAsync<ZipResponse>(url);
        }
    }
}