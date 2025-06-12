using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    /// <summary>
    /// Provides functionality to retrieve company information based on a CNPJ (Cadastro Nacional da Pessoa Jurídica),
    /// the Brazilian company registration number.
    /// </summary>
    /// <remarks>The <see cref="CnpjSearch"/> class enables users to query company details using a valid CNPJ.
    /// It supports both synchronous and asynchronous methods for retrieving data, and allows optional inclusion of
    /// state registration details in the response. Instances of this class can be created using an authentication token
    /// or a pre-configured <see cref="HubDev"/> instance.</remarks>
    public sealed class CnpjSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;

        /// <summary>
        /// Initializes a new instance of the <see cref="CnpjSearch"/> class.
        /// </summary>
        /// <remarks>The <see cref="HubDev"/> instance provided must be properly configured to enable CNPJ
        /// searches.</remarks>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to perform CNPJ-related operations.</param>
        public CnpjSearch(HubDev hubDev)
        {
            _hubDev = hubDev;
        }

        /// <summary>
        /// Retrieves information about a company based on its CNPJ (Cadastro Nacional da Pessoa Jurídica).
        /// </summary>
        /// <remarks>This method performs an HTTP request to retrieve company information. Ensure that the
        /// provided CNPJ is valid and formatted correctly to avoid errors.</remarks>
        /// <param name="cnpj">The CNPJ of the company to retrieve information for. Must be a valid CNPJ string.</param>
        /// <param name="stateRegistration">A boolean value indicating whether to include state registration information in the response. Pass <see
        /// langword="true"/> to include state registration details; otherwise, <see langword="false"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CnpjResponse"/>
        /// object with the company's information.</returns>
        public Task<CnpjResponse> GetAsync(string cnpj, bool stateRegistration = false)
        {            
            return _httpClient.GetObjectAsync<CnpjResponse>(GetRenderUrl(cnpj, stateRegistration));
        }

        /// <summary>
        /// Retrieves information about a company based on its CNPJ (Brazilian company registration number).
        /// </summary>
        /// <param name="cnpj">The CNPJ of the company to retrieve information for. Must be a valid CNPJ format.</param>
        /// <param name="stateRegistration">A boolean value indicating whether to include state registration details in the response. <see
        /// langword="true"/> to include state registration details; otherwise, <see langword="false"/>.</param>
        /// <returns>A <see cref="CnpjResponse"/> object containing the company's information, including registration details.</returns>
        public CnpjResponse Get(string cnpj, bool stateRegistration = false)
        {            
            return _httpClient.GetObject<CnpjResponse>(GetRenderUrl(cnpj, stateRegistration));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CnpjSearch"/> class using the specified authentication token.
        /// </summary>
        /// <param name="token">The authentication token used to initialize the <see cref="CnpjSearch"/> instance. Cannot be null or empty.</param>
        /// <returns>A new <see cref="CnpjSearch"/> instance configured with the provided token.</returns>
        public static CnpjSearch Create(string token)
        {
            return new CnpjSearch(new HubDev(token));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CnpjSearch"/> class using the specified <see cref="HubDev"/>
        /// instance.
        /// </summary>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to initialize the <see cref="CnpjSearch"/> object. Cannot be null.</param>
        /// <returns>A new <see cref="CnpjSearch"/> object initialized with the provided <see cref="HubDev"/> instance.</returns>
        public static CnpjSearch Create(HubDev hubDev)
        {
            return new CnpjSearch(hubDev);
        }

        #region private
        private string GetRenderUrl(string cnpj, bool stateRegistration = false)
        {
            return stateRegistration ?
                _urlAddress.GetUrlCNPJWithIE(cnpj, _hubDev.Token) :
                _urlAddress.GetUrlCNPJ(cnpj, _hubDev.Token);
        }
        #endregion
    }
}