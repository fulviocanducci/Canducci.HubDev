using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    /// <summary>
    /// Provides functionality to search and retrieve CPF Plus data using hub services.
    /// </summary>
    /// <remarks>The <see cref="CpfPlusSearch"/> class enables interaction with CPF Plus services, allowing
    /// users to retrieve data associated with a specific CPF identifier. This class requires a properly initialized
    /// <see cref="HubDev"/> instance for its operations. Use the <see cref="Create(string)"/> method to create an
    /// instance with an authentication token, or initialize it directly with a <see cref="HubDev"/> instance.</remarks>
    public sealed class CpfPlusSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;

        /// <summary>
        /// Initializes a new instance of the <see cref="CpfPlusSearch"/> class.
        /// </summary>
        /// <remarks>The <see cref="CpfPlusSearch"/> class depends on the provided <see cref="HubDev"/>
        /// instance for its operations. Ensure that the <paramref name="hubDev"/> parameter is properly initialized
        /// before passing it to this constructor.</remarks>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to interact with the underlying hub services.</param>
        public CpfPlusSearch(HubDev hubDev)
        {
            _hubDev = hubDev ?? throw new System.ArgumentNullException(nameof(hubDev));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CpfPlusSearch"/> class using the specified token and contract.
        /// </summary>
        /// <param name="token">The authentication token used to access the service. This parameter is required and cannot be null or empty.</param>
        /// <param name="contract">The contract identifier associated with the service. If not specified, the default contract will be used.</param>
        public CpfPlusSearch(string token, string contract = default) : this(new HubDev(token, contract))
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new System.ArgumentException($"'{nameof(token)}' cannot be null or empty.", nameof(token));
            }
        }

        /// <summary>
        /// Retrieves a <see cref="CpfPlusResponse"/> object asynchronously for the specified CPF.
        /// </summary>
        /// <remarks>This method sends an HTTP GET request to retrieve the data associated with the
        /// provided CPF. Ensure the CPF is valid and properly formatted before calling this method.</remarks>
        /// <param name="cpf">The CPF identifier used to fetch the associated response. Must be a valid, non-null CPF string.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="CpfPlusResponse"/>
        /// object corresponding to the specified CPF.</returns>
        public Task<CpfPlusResponse> GetAsync(string cpf)
        {
            return _httpClient.GetObjectAsync<CpfPlusResponse>(GetRenderUrl(cpf));
        }

        /// <summary>
        /// Retrieves a <see cref="CpfPlusResponse"/> object for the specified CPF.
        /// </summary>
        /// <param name="cpf">The CPF (Cadastro de Pessoas Físicas) identifier for which the response is requested. Cannot be null or
        /// empty.</param>
        /// <returns>A <see cref="CpfPlusResponse"/> object containing the data associated with the specified CPF.</returns>
        public CpfPlusResponse Get(string cpf)
        {
            return _httpClient.GetObject<CpfPlusResponse>(GetRenderUrl(cpf));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CpfPlusSearch"/> class using the specified authentication token.
        /// </summary>
        /// <param name="token">The authentication token used to initialize the <see cref="HubDev"/> instance. Cannot be null or empty.</param>
        /// <returns>A new <see cref="CpfPlusSearch"/> instance configured with the provided token.</returns>
        public static CpfPlusSearch Create(string token, string contract = default)
        {
            return Create(new HubDev(token, contract));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CpfPlusSearch"/> class using the specified <see cref="HubDev"/>
        /// instance.
        /// </summary>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to initialize the <see cref="CpfPlusSearch"/> object. Cannot be null.</param>
        /// <returns>A new <see cref="CpfPlusSearch"/> object initialized with the provided <see cref="HubDev"/> instance.</returns>
        public static CpfPlusSearch Create(HubDev hubDev)
        {
            return new CpfPlusSearch(hubDev);
        }

        #region private
        private string GetRenderUrl(string cpf)
        {
            return _urlAddress.GetUrlCPFPlus(cpf, _hubDev.Token, _hubDev.Contract);
        }
        #endregion
    }
}
