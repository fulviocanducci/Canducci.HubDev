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
            _hubDev = hubDev;
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

        #region private
        private string GetRenderUrl()
        {
            return _urlAddress.GetUrlBalance(_hubDev.Token);
        }
        #endregion
    }
}
