using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{    
    public class ZipCodeResponse
    {
        [JsonConstructor()]
        public ZipCodeResponse(string zip, string street, string complement, string neighborhood, string city, string state, string unit, string ibgeCode, string giaCode)
        {
            Zip = zip;
            Street = street;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Unit = unit;
            IbgeCode = ibgeCode;
            GiaCode = giaCode;
        }

        [JsonProperty("cep")]
        public string Zip { get; private set; }

        [JsonProperty("logradouro")]
        public string Street { get; private set; }

        [JsonProperty("complemento")]
        public string Complement { get; private set; }

        [JsonProperty("bairro")]
        public string Neighborhood { get; private set; }

        [JsonProperty("localidade")]
        public string City { get; private set; }

        [JsonProperty("uf")]
        public string State { get; private set; }

        [JsonProperty("unidade")]
        public string Unit { get; private set; }

        [JsonProperty("ibge")]
        public string IbgeCode { get; private set; }

        [JsonProperty("gia")]
        public string GiaCode { get; private set; }
    }

}
