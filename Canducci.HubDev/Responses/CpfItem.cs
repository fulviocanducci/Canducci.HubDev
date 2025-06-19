using System;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Canducci.HubDev.Responses
{
    public class CpfItem
    {
        [JsonConstructor()]
        public CpfItem(string cpfNumber, string fullName, string dateOfBirth, string registrationStatus, string registrationDate, string checkDigit, string proofCode, string proofTimestamp)
        {
            CpfNumber = cpfNumber;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            RegistrationStatus = registrationStatus;
            RegistrationDate = registrationDate;
            CheckDigit = checkDigit;
            ProofCode = proofCode;
            ProofTimestamp = proofTimestamp;
        }

        [JsonProperty("numero_de_cpf")]
        public string CpfNumber { get; private set; }

        [JsonProperty("nome_da_pf")]
        public string FullName { get; private set; }

        [JsonProperty("data_nascimento")]
        public string DateOfBirth { get; private set; }

        [JsonProperty("situacao_cadastral")]
        public string RegistrationStatus { get; private set; }

        [JsonProperty("data_inscricao")]
        public string RegistrationDate { get; private set; }

        [JsonProperty("digito_verificador")]
        public string CheckDigit { get; private set; }

        [JsonProperty("comprovante_emitido")]
        public string ProofCode { get; private set; }

        [JsonProperty("comprovante_emitido_data")]
        public string ProofTimestamp { get; private set; }
    }

}
