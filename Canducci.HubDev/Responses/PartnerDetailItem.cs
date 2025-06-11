using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class PartnerDetailItem
    {
        [JsonConstructor()]
        public PartnerDetailItem(string information)
        {
            Information = information;
        }

        [JsonProperty("informacoes")]
        public string Information { get; private set; }
    }
}
