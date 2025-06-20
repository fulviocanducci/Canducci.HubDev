using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    /// <summary>
    /// Provides functionality for searching CPF (Cadastro de Pessoas Físicas) information using an external service.
    /// </summary>
    /// <remarks>This class encapsulates methods for retrieving CPF-related data asynchronously or
    /// synchronously. It requires a valid <see cref="HubDev"/> instance, which contains authentication details. Use the
    /// static <see cref="Create(string)"/> or <see cref="Create(HubDev)"/> methods to instantiate this class.</remarks>
    public sealed class CpfSearch
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
        public CpfSearch(HubDev hubDev)
        {
            _hubDev = hubDev ?? throw new ArgumentNullException(nameof(hubDev));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CpfSearch"/> class using the specified authentication token.
        /// </summary>
        /// <param name="token">The authentication token used to access the CPF search service.  This token must be a valid string and
        /// cannot be null or empty.</param>
        public CpfSearch(string token) : this(new HubDev(token))
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException($"'{nameof(token)}' cannot be null or empty.", nameof(token));
            }
        }

        /// <summary>
        /// Retrieves CPF-related information asynchronously.
        /// </summary>
        /// <remarks>This method sends an HTTP GET request to retrieve information based on the provided
        /// CPF and birth date. Ensure that the CPF and birth date are valid and correctly formatted before calling this
        /// method.</remarks>
        /// <param name="cpf">The CPF (Cadastro de Pessoas Físicas) identifier to query. Must be a valid CPF string.</param>
        /// <param name="birthdata">The birth date associated with the CPF. Used to validate the query.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CpfResponse"/>
        /// object  with the retrieved information.</returns>
        public Task<CpfResponse> GetAsync(string cpf, DateTime birthdata)
        {
            return _httpClient.GetObjectAsync<CpfResponse>(GetRenderUrl(cpf, birthdata));
        }

        /// <summary>
        /// Retrieves CPF-related information for the specified CPF and birth date.
        /// </summary>
        /// <param name="cpf">The CPF (Cadastro de Pessoas Físicas) identifier to query. Must be a valid CPF string.</param>
        /// <param name="birthdata">The birth date associated with the CPF. Used to validate the query.</param>
        /// <returns>A <see cref="CpfResponse"/> object containing the retrieved information for the specified CPF and birth
        /// date.</returns>
        public CpfResponse Get(string cpf, DateTime birthdata)
        {
            return _httpClient.GetObject<CpfResponse>(GetRenderUrl(cpf, birthdata));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CpfSearch"/> class using the specified authentication token.
        /// </summary>
        /// <param name="token">The authentication token used to initialize the <see cref="HubDev"/> instance. Cannot be null or empty.</param>
        /// <returns>A new <see cref="CpfSearch"/> object initialized with the provided token.</returns>
        public static CpfSearch Create(string token)
        {
            return Create(new HubDev(token));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CpfSearch"/> class using the specified <see cref="HubDev"/>
        /// instance.
        /// </summary>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to initialize the <see cref="CpfSearch"/> object. Cannot be null.</param>
        /// <returns>A new instance of the <see cref="CpfSearch"/> class.</returns>
        public static CpfSearch Create(HubDev hubDev)
        {
            return new CpfSearch(hubDev);
        }

        #region private
        private string GetRenderUrl(string cpf, DateTime birthdata)
        {
            return _urlAddress.GetUrlCPF(cpf, birthdata, _hubDev.Token);
        }
        #endregion
    }
}