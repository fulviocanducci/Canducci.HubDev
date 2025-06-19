using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    public sealed class CpfPlusSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;

        /// <summary>
        /// Initializes a new instance of the <see cref="CpfSearch"/> class.
        /// </summary>
        /// <remarks>The <paramref name="hubDev"/> parameter is required to interact with the underlying
        /// hub for CPF searches. Ensure that the provided <see cref="HubDev"/> instance is properly initialized before
        /// using this class.</remarks>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to perform CPF-related operations.</param>
        public CpfPlusSearch(HubDev hubDev)
        {
            _hubDev = hubDev;
        }

        public Task<CpfResponse> GetAsync(string cpf, DateTime birthdata)
        {
            return _httpClient.GetObjectAsync<CpfResponse>(GetRenderUrl(cpf, birthdata));
        }
        public CpfResponse Get(string cpf, DateTime birthdata)
        {
            return _httpClient.GetObject<CpfResponse>(GetRenderUrl(cpf, birthdata));
        }
        public static CpfSearch Create(string token)
        {
            return new CpfSearch(new HubDev(token));
        }
        #region private
        private string GetRenderUrl(string cpf, DateTime birthdata)
        {
            return _urlAddress.GetUrlCPF(cpf, birthdata, _hubDev.Token);
        }
        #endregion
    }
}
