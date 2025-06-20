using Canducci.HubDev.Internals;
using Canducci.HubDev.Responses;
using System.Threading.Tasks;
namespace Canducci.HubDev
{
    /// <summary>
    /// Provides functionality to retrieve balance information from a server.
    /// </summary>
    /// <remarks>This class is designed to interact with a server to fetch balance-related data. It requires
    /// an instance of <see cref="HubDev"/> to be provided during initialization, which is used to configure the
    /// necessary parameters for the requests. The class supports both synchronous and asynchronous methods for
    /// retrieving balance information.</remarks>
    public sealed class BalanceSearch
    {
        private readonly UrlAddress _urlAddress = UrlAddress.Instance;
        private readonly HttpClient _httpClient = HttpClient.Instance;
        private readonly HubDev _hubDev;

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceSearch"/> class with the specified hub device.
        /// </summary>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to perform balance-related operations.  This parameter cannot be
        /// null.</param>
        public BalanceSearch(HubDev hubDev)
        {
            _hubDev = hubDev ?? throw new System.ArgumentNullException(nameof(hubDev));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceSearch"/> class using the specified authentication
        /// token.
        /// </summary>
        /// <remarks>This constructor creates a <see cref="BalanceSearch"/> instance with a default <see
        /// cref="HubDev"/> client. Ensure the provided token is valid and authorized for the intended
        /// operations.</remarks>
        /// <param name="token">The authentication token used to access the service. Cannot be null or empty.</param>
        public BalanceSearch(string token) : this(new HubDev(token))
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new System.ArgumentException($"'{nameof(token)}' cannot be null or empty.", nameof(token));
            }
        }

        /// <summary>
        /// Asynchronously retrieves the balance information from the server.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="BalanceResponse"/>
        /// object with the balance details retrieved from the server.</returns>
        public Task<BalanceResponse> GetAsync()
        {
            return _httpClient.GetObjectAsync<BalanceResponse>(GetRenderUrl());
        }

        /// <summary>
        /// Retrieves the current balance information.
        /// </summary>
        /// <remarks>This method sends a request to the configured endpoint and returns the balance data.
        /// Ensure that the HTTP client is properly configured before calling this method.</remarks>
        /// <returns>A <see cref="BalanceResponse"/> object containing the current balance details.</returns>
        public BalanceResponse Get()
        {
            return _httpClient.GetObject<BalanceResponse>(GetRenderUrl());
        }

        /// <summary>
        /// Creates a new instance of <see cref="BalanceSearch"/> using the specified <see cref="HubDev"/>.
        /// </summary>
        /// <param name="hubDev">The <see cref="HubDev"/> instance used to initialize the <see cref="BalanceSearch"/>.</param>
        /// <returns>A new instance of <see cref="BalanceSearch"/> initialized with the provided <see cref="HubDev"/>.</returns>
        public static BalanceSearch Create(HubDev hubDev)
        {
            return Create(hubDev);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BalanceSearch"/> class using the specified token.
        /// </summary>
        /// <param name="token">The authentication token used to initialize the <see cref="BalanceSearch"/> instance. Cannot be null or
        /// empty.</param>
        /// <returns>A new <see cref="BalanceSearch"/> instance initialized with the provided token.</returns>
        public static BalanceSearch Create(string token)
        {
            return new BalanceSearch(token);
        }

        #region private
        private string GetRenderUrl()
        {
            return _urlAddress.GetUrlBalance(_hubDev.Token);
        }
        #endregion
    }
}
