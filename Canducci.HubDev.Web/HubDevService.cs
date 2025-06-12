namespace Canducci.HubDev.Web
{
    public class HubDevService : IHubDevService
    {
        /// <summary>
        /// Gets the CPF search functionality for querying and managing CPF-related data.
        /// </summary>
        public CpfSearch CpfSearch { get; }
        /// <summary>
        /// Gets the CNPJ search functionality for retrieving information related to Brazilian company registrations.
        /// </summary>
        public CnpjSearch CnpjSearch { get; }
        /// <summary>
        /// 
        /// </summary>
        public ZipSearch ZipSearch { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HubDevService"/> class, providing services for CPF, CNPJ, and
        /// ZIP code searches.
        /// </summary>
        /// <param name="cpfSearch">The service used for CPF (Cadastro de Pessoas Físicas) searches. Cannot be null.</param>
        /// <param name="cnpjSearch">The service used for CNPJ (Cadastro Nacional da Pessoa Jurídica) searches. Cannot be null.</param>
        /// <param name="zipSearch">The service used for ZIP code searches. Cannot be null.</param>
        public HubDevService(CpfSearch cpfSearch, CnpjSearch cnpjSearch, ZipSearch zipSearch)
        {
            CpfSearch = cpfSearch;
            CnpjSearch = cnpjSearch;
            ZipSearch = zipSearch;
        }
    }
}
