using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class PhoneItem
    {
        [JsonProperty("telefoneComDDD")]
        public string PhoneWithAreaCode { get; set; }

        [JsonProperty("telemarketingBloqueado")]
        public string TelemarketingBlocked { get; set; }

        [JsonProperty("operadora")]
        public string Carrier { get; set; }

        [JsonProperty("tipoTelefone")]
        public string PhoneType { get; set; }

        [JsonProperty("whatsApp")]
        public string WhatsApp { get; set; }
    }


}
