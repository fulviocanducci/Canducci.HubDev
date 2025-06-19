using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class AddressItem
    {
        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [JsonProperty("numero")]
        public string Number { get; set; }

        [JsonProperty("complemento")]
        public string Complement { get; set; }

        [JsonProperty("bairro")]
        public string District { get; set; }

        [JsonProperty("cidade")]
        public string City { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }

        [JsonProperty("cep")]
        public string ZipCode { get; set; }
    }


}
