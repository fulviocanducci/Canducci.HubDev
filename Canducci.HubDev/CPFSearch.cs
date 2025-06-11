using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    public sealed class CPFSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;
        public CPFSearch(HubDev hubDev)
        {
            _hubDev = hubDev;
        }
        public CPFSearch(string token)
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
