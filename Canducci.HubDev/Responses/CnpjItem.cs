using Newtonsoft.Json;
using System.Collections.Generic;
namespace Canducci.HubDev.Responses
{
    public class CnpjItem
    {
        [JsonConstructor()]
        public CnpjItem(string registrationNumber, string type, string openingDate, string legalName, string tradeName, string companySize, ActivityItem mainActivity, List<ActivityItem> secondaryActivities, string legalNature, string street, string number, string complement, string postalCode, string neighborhood, string city, string state, string email, string phone, string federalEntityResponsible, string status, string registrationStatusDate, string registrationStatusReason, string specialStatus, string specialStatusDate, string shareCapital, List<string> partners, List<PartnerDetailItem> partnerDetails, StateRegistrationItem stateRegistrations)
        {
            RegistrationNumber = registrationNumber;
            Type = type;
            OpeningDate = openingDate;
            LegalName = legalName;
            TradeName = tradeName;
            CompanySize = companySize;
            MainActivity = mainActivity;
            SecondaryActivities = secondaryActivities;
            LegalNature = legalNature;
            Street = street;
            Number = number;
            Complement = complement;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Email = email;
            Phone = phone;
            FederalEntityResponsible = federalEntityResponsible;
            Status = status;
            RegistrationStatusDate = registrationStatusDate;
            RegistrationStatusReason = registrationStatusReason;
            SpecialStatus = specialStatus;
            SpecialStatusDate = specialStatusDate;
            ShareCapital = shareCapital;
            Partners = partners;
            PartnerDetails = partnerDetails;
            StateRegistrations = stateRegistrations;
        }

        [JsonProperty("numero_de_inscricao")]
        public string RegistrationNumber { get; private set; }

        [JsonProperty("tipo")]
        public string Type { get; private set; }

        [JsonProperty("abertura")]
        public string OpeningDate { get; private set; }

        [JsonProperty("nome")]
        public string LegalName { get; private set; }

        [JsonProperty("fantasia")]
        public string TradeName { get; private set; }

        [JsonProperty("porte")]
        public string CompanySize { get; private set; }

        [JsonProperty("atividade_principal")]
        public ActivityItem MainActivity { get; private set; }

        [JsonProperty("atividades_secundarias")]
        public List<ActivityItem> SecondaryActivities { get; private set; } = new List<ActivityItem>();

        [JsonProperty("natureza_juridica")]
        public string LegalNature { get; private set; }

        [JsonProperty("logradouro")]
        public string Street { get; private set; }

        [JsonProperty("numero")]
        public string Number { get; private set; }

        [JsonProperty("complemento")]
        public string Complement { get; private set; }

        [JsonProperty("cep")]
        public string PostalCode { get; private set; }

        [JsonProperty("bairro")]
        public string Neighborhood { get; private set; }

        [JsonProperty("municipio")]
        public string City { get; private set; }

        [JsonProperty("uf")]
        public string State { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("telefone")]
        public string Phone { get; private set; }

        [JsonProperty("entidade_federativo_responsavel")]
        public string FederalEntityResponsible { get; private set; }

        [JsonProperty("situacao")]
        public string Status { get; private set; }

        [JsonProperty("dt_situacao_cadastral")]
        public string RegistrationStatusDate { get; private set; }

        [JsonProperty("motivo_situacao_cadastral")]
        public string RegistrationStatusReason { get; private set; }

        [JsonProperty("situacao_especial")]
        public string SpecialStatus { get; private set; }

        [JsonProperty("data_situacao_especial")]
        public string SpecialStatusDate { get; private set; }

        [JsonProperty("capital_social")]
        public string ShareCapital { get; private set; }

        [JsonProperty("quadro_socios")]
        public List<string> Partners { get; private set; } = new List<string>();

        [JsonProperty("quadro_de_socios")]
        public List<PartnerDetailItem> PartnerDetails { get; private set; } = new List<PartnerDetailItem>();

        [JsonProperty("inscricoes_estaduais")]
        public StateRegistrationItem StateRegistrations { get; private set; }
    }
}
