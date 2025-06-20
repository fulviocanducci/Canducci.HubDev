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
        /// Gets the unique identifier for the object.
        /// </summary>
        public readonly string Id;
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
            Id = System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets the authentication token used for accessing secured resources.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the contract identifier associated with the current instance.
        /// </summary>
        public string Contract { get; private set; }

        #region Singleton Implementation
        /// <summary>
        /// Represents the singleton instance of the <see cref="HubDev"/> class.
        /// </summary>
        /// <remarks>This field holds the single instance of the <see cref="HubDev"/> class, ensuring that
        /// only one instance exists throughout the application's lifetime. Access to this instance is typically managed
        /// through a public property or method.</remarks>
        private static HubDev _instance;

        /// <summary>
        /// A private static object used as a synchronization lock to ensure thread safety.
        /// </summary>
        /// <remarks>This lock object is intended for use in critical sections where multiple threads may
        /// access shared resources. It should be used with a <c>lock</c> statement to prevent race
        /// conditions.</remarks>
        private static readonly object _lock = new object();

        /// <summary>
        /// Gets the singleton instance of the <see cref="HubDev"/> class.
        /// </summary>
        public static HubDev Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new System.InvalidOperationException("Instance not set. Use SetInstance method to initialize.");
                }                
                return _instance;
            }
        }

        /// <summary>
        /// Initializes or retrieves the singleton instance of the <see cref="HubDev"/> class.
        /// </summary>
        /// <remarks>This method ensures thread-safe initialization of the singleton instance. If the
        /// instance has already been initialized, the existing instance is returned. Subsequent calls with different
        /// parameters will not reinitialize the instance.</remarks>
        /// <param name="token">The authentication token used to initialize the instance. This parameter cannot be null or empty.</param>
        /// <param name="contract">An optional contract identifier used for configuration. If not provided, the default value is used.</param>
        /// <returns>The singleton instance of the <see cref="HubDev"/> class.</returns>
        /// <exception cref="System.ArgumentException">Thrown if <paramref name="token"/> is null or empty.</exception>
        public static HubDev SetInstance(string token, string contract = default)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new System.ArgumentException($"'{nameof(token)}' cannot be null or empty.", nameof(token));
            }
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new HubDev(token, contract);
                    }
                }
            }
            return _instance;
        }
        #endregion
    }
}
