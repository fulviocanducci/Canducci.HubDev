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

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("qualificacao")]
        public string Qualification { get; set; }

        [JsonProperty("pais_de_origem")]
        public string CountryOfOrigin { get; set; }

        [JsonProperty("nome_representante_legal")]
        public string LegalRepresentativeName { get; set; }

        [JsonProperty("qualificacao_representante_legal")]
        public string LegalRepresentativeQualification { get; set; }
    }
}

