using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Canducci.HubDev.Responses
{
    public class BalanceItem
    {
        [JsonConstructor]
        public BalanceItem(string exclusiveServer, string token, string id, string saldo, string saldoRegistration, string ativo)
        {
            ExclusiveServer = exclusiveServer;
            Token = token;
            Id = id;
            Saldo = saldo;
            SaldoRegistration = saldoRegistration;
            Ativo = ativo;
        }

        [JsonProperty("servidor_exclusivo")]
        public string ExclusiveServer { get; private set; }

        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("saldo")]
        public string Saldo { get; private set; }

        [JsonProperty("saldo_cadastrais")]
        public string SaldoRegistration { get; private set; }

        [JsonProperty("ativo")]
        public string Ativo { get; private set; }
    }

}
