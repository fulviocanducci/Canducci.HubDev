using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    /// <summary>
    /// Provides functionality for retrieving information about ZIP codes.
    /// </summary>
    /// <remarks>The <see cref="ZipSearch"/> class allows users to query details about ZIP codes using HTTP
    /// requests. It supports both synchronous and asynchronous methods for retrieving data. Instances of this class can
    /// be created using a token or a <see cref="HubDev"/> object for authentication.</remarks>
    public sealed class ZipSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipSearch"/> class.
        /// </summary>
        /// <remarks>The <paramref name="hubDev"/> parameter is required to provide the necessary
        /// functionality for zip code-related operations. Ensure that the provided <see cref="HubDev"/> instance is
        /// properly initialized before passing it to this constructor.</remarks>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to perform operations related to zip code searches.</param>
        public ZipSearch(HubDev hubDev)
        {
            _hubDev = hubDev;
        }
        
        /// <summary>
        /// Retrieves information about a ZIP code asynchronously.
        /// </summary>
        /// <remarks>This method constructs a URL using the provided ZIP code and authentication token, 
        /// then performs an HTTP GET request to retrieve the corresponding data.</remarks>
        /// <param name="zip">The ZIP code to query. Must be a valid ZIP code format.</param>
        /// <returns>A <see cref="ZipResponse"/> object containing details about the specified ZIP code.</returns>
        public Task<ZipResponse> GetAsync(string zip)
        {
            return _httpClient.GetObjectAsync<ZipResponse>(GetRenderUrl(zip));
        }

        /// <summary>
        /// Retrieves information about a ZIP code.
        /// </summary>
        /// <param name="zip">The ZIP code to query. Must be a valid ZIP code format.</param>
        /// <returns>A <see cref="ZipResponse"/> object containing details about the specified ZIP code.</returns>
        public ZipResponse Get(string zip)
        {
            return _httpClient.GetObject<ZipResponse>(GetRenderUrl(zip));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ZipSearch"/> class using the specified authentication token.
        /// </summary>
        /// <param name="token">The authentication token used to initialize the underlying service. Cannot be null or empty.</param>
        /// <returns>A new instance of the <see cref="ZipSearch"/> class.</returns>
        public static ZipSearch Create(string token)
        {
            return new ZipSearch(new HubDev(token));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ZipSearch"/> class using the specified <see cref="HubDev"/>
        /// instance.
        /// </summary>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to initialize the <see cref="ZipSearch"/> object. Cannot be null.</param>
        /// <returns>A new <see cref="ZipSearch"/> object initialized with the provided <see cref="HubDev"/> instance.</returns>
        public static ZipSearch Create(HubDev hubDev)
        {
            return new ZipSearch(hubDev);
        }

        #region private
        private string GetRenderUrl(string zip) 
        {
            return _urlAddress.GetUrlZip(zip, _hubDev.Token);
        }
        #endregion
    }
}