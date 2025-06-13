
namespace Canducci.HubDev.Web
{
    /// <summary>
    /// Provides access to various search functionalities for retrieving and managing data related to balances, CNPJs,
    /// CPFs, and ZIP codes.
    /// </summary>
    /// <remarks>This interface serves as a central point for accessing specialized search services. Each
    /// property exposes a specific search functionality: <list type="bullet"> <item> <description><see
    /// cref="BalanceSearch"/> provides methods for retrieving balance-related data.</description> </item> <item>
    /// <description><see cref="CnpjSearch"/> provides methods for retrieving and managing data related to CNPJs
    /// (Cadastro Nacional da Pessoa Jurídica).</description> </item> <item> <description><see cref="CpfSearch"/>
    /// provides methods for querying data related to CPFs (Cadastro de Pessoas Físicas).</description> </item> <item>
    /// <description><see cref="ZipSearch"/> provides methods for retrieving information based on ZIP
    /// codes.</description> </item> </list></remarks>
    public interface IHubDevService
    {
        /// <summary>
        /// Gets the search functionality for retrieving balance-related data.
        /// </summary>
        BalanceSearch BalanceSearch { get; }
        /// <summary>
        /// Gets the CNPJ search functionality for retrieving and managing CNPJ-related data.
        /// </summary>
        CnpjSearch CnpjSearch { get; }
        /// <summary>
        /// Gets the CPF search functionality for querying CPF-related data.
        /// </summary>
        CpfSearch CpfSearch { get; }
        /// <summary>
        /// Gets the search functionality for retrieving information based on ZIP codes.
        /// </summary>
        ZipSearch ZipSearch { get; }
    }
}