namespace Canducci.HubDev.Web
{
    /// <summary>
    /// Provides a centralized service for accessing various search functionalities, including CPF, CNPJ, ZIP code, and
    /// balance-related searches.
    /// </summary>
    /// <remarks>The <see cref="HubDevService"/> class acts as a hub for multiple search services, enabling
    /// streamlined access to CPF, CNPJ, ZIP code, and balance-related data. This service is designed to support
    /// dependency injection, allowing for flexible and testable configurations.</remarks>
    public class HubDevService : IHubDevService
    {
        /// <summary>
        /// Gets the search functionality for retrieving balance-related data.
        /// </summary>
        public BalanceSearch BalanceSearch { get; }
        /// <summary>
        /// Gets the CPF search functionality for querying and managing CPF-related data.
        /// </summary>
        public CpfSearch CpfSearch { get; }
        /// <summary>
        /// Gets the CNPJ search functionality for retrieving information related to Brazilian company registrations.
        /// </summary>
        public CnpjSearch CnpjSearch { get; }
        /// <summary>
        /// Gets the functionality for searching and retrieving information based on ZIP codes.
        /// </summary>
        public ZipSearch ZipSearch { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HubDevService"/> class with the specified search services.
        /// </summary>
        /// <remarks>This constructor allows dependency injection of the required search services,
        /// enabling flexible and testable configurations.</remarks>
        /// <param name="cpfSearch">The service used for CPF (Cadastro de Pessoas Físicas) searches.</param>
        /// <param name="cnpjSearch">The service used for CNPJ (Cadastro Nacional da Pessoa Jurídica) searches.</param>
        /// <param name="zipSearch">The service used for ZIP code searches.</param>
        /// <param name="balanceSearch">The service used for balance-related searches.</param>
        public HubDevService(CpfSearch cpfSearch, CnpjSearch cnpjSearch, ZipSearch zipSearch, BalanceSearch balanceSearch)
        {
            CpfSearch = cpfSearch;
            CnpjSearch = cnpjSearch;
            ZipSearch = zipSearch;
            BalanceSearch = balanceSearch;
        }
    }
}
