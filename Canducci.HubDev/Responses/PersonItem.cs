using Canducci.HubDev.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Canducci.HubDev.Responses
{
    public class PersonItem
    {
        [JsonConstructor()]
        public PersonItem
        (
            string personCode,
            string fullName,
            string gender,
            DateTime? birthDate,
            string document,
            string mothersName,
            int age,
            string zodiac,
            List<PhoneItem> phoneList,
            List<AddressItem> addressList,
            List<EmailItem> emailList,
            decimal estimatedSalary,
            string registrationStatus,
            DateTime? registrationStatusDate,
            DateTime? lastUpdate
        )
        {
            PersonCode = personCode;
            FullName = fullName;
            Gender = gender;
            BirthDate = birthDate;
            Document = document;
            MothersName = mothersName;
            Age = age;
            Zodiac = zodiac;
            PhoneList = phoneList;
            AddressList = addressList;
            EmailList = emailList;
            EstimatedSalary = estimatedSalary;
            RegistrationStatus = registrationStatus;
            RegistrationStatusDate = registrationStatusDate;
            LastUpdate = lastUpdate;
        }

        [JsonProperty("codigoPessoa")]
        public string PersonCode { get; private set; }

        [JsonProperty("nomeCompleto")]
        public string FullName { get; private set; }

        [JsonProperty("genero")]
        public string Gender { get; private set; }

        [JsonProperty("dataDeNascimento")]
        [JsonConverter(typeof(BrazilianDateConverter), "dd/MM/yyyy")]
        public DateTime? BirthDate { get; private set; }

        [JsonProperty("documento")]
        public string Document { get; private set; }

        [JsonProperty("nomeDaMae")]
        public string MothersName { get; private set; }

        [JsonProperty("anos")]
        public int Age { get; private set; }

        [JsonProperty("zodiaco")]
        public string Zodiac { get; private set; }

        [JsonProperty("listaTelefones")]
        public List<PhoneItem> PhoneList { get; private set; }

        [JsonProperty("listaEnderecos")]
        public List<AddressItem> AddressList { get; private set; }

        [JsonProperty("listaEmails")]
        public List<EmailItem> EmailList { get; private set; }

        [JsonProperty("salarioEstimado")]
        [JsonConverter(typeof(BrazilianDecimalConverter))]
        public decimal EstimatedSalary { get; private set; }

        [JsonProperty("statusCadastral")]
        public string RegistrationStatus { get; private set; }

        [JsonProperty("dataStatusCadastral")]
        [JsonConverter(typeof(BrazilianDateConverter), "dd/MM/yyyy")]
        public DateTime? RegistrationStatusDate { get; private set; }

        [JsonProperty("lastUpdate")]
        [JsonConverter(typeof(BrazilianDateConverter), "dd/MM/yyyy")]
        public DateTime? LastUpdate { get; private set; }
    }
}
