using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    public sealed class CpfSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;
        public CpfSearch(HubDev hubDev)
        {
            _hubDev = hubDev;
        }
        public CpfSearch(string token)
        {
            _hubDev = new HubDev(token);
        }
        public async Task<CpfResponse> GetAsync(string cpf, DateTime birthdata)
        {
            string url = _urlAddress.GetUrlCPF(cpf, birthdata, _hubDev.Token);
            return await _httpClient.GetObjectAsync<CpfResponse>(url);
        }
    }
}
