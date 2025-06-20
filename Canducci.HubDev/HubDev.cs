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
        /// Initializes a new instance of the <see cref="HubDev"/> class with the specified token and contract.
        /// </summary>
        /// <remarks>Both <paramref name="token"/> and <paramref name="contract"/> must be valid and
        /// non-null. Ensure that the provided token has the necessary permissions for the specified contract.</remarks>
        /// <param name="token">The authentication token used to access the hub.</param>
        /// <param name="contract">The contract identifier associated with the hub.</param>
        public HubDev(string token, string contract = default)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new System.ArgumentException($"'{nameof(token)}' cannot be null or empty.", nameof(token));
            }
            Token = token;
            Contract = contract;
        }

        /// <summary>
        /// Gets the authentication token used for accessing secured resources.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the contract identifier associated with the current instance.
        /// </summary>
        public string Contract { get; private set; }
    }
}
