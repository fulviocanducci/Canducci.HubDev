using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class EmailItem
    {
        [JsonProperty("enderecoEmail")]
        public string EmailAddress { get; set; }
    }

}
