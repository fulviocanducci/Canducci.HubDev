namespace Canducci.HubDev
{
    /// <summary>
    /// Represents a development hub that requires authentication via a token.
    /// </summary>
    /// <remarks>This class is immutable after initialization. The token provided during construction is used 
    /// to authenticate interactions with the hub.</remarks>
    public sealed class HubDev
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HubDev"/> class using the specified authentication token.
        /// </summary>
        /// <param name="token">The authentication token used to connect to the HubDev service.  This token must be a valid, non-empty
        /// string.</param>
        public HubDev(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Gets the authentication token used for accessing secured resources.
        /// </summary>
        public string Token { get; private set; }
    }
}
