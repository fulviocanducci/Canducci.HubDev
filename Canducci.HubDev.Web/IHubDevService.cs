
namespace Canducci.HubDev.Web
{
    public interface IHubDevService
    {
        CnpjSearch CnpjSearch { get; }
        CpfSearch CpfSearch { get; }
        ZipSearch ZipSearch { get; }
    }
}