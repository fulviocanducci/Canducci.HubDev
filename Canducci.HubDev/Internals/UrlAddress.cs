using System;
namespace Canducci.HubDev.Internals
{
    internal class UrlAddress
    {
        private readonly string UrlCNPJ = "http://ws.hubdodesenvolvedor.com.br/v2/cnpj/?cnpj={0}&token={1}";
        private readonly string UrlCPF = "https://ws.hubdodesenvolvedor.com.br/v2/cpf/?cpf={0}&data={1}&token={2}";
        private readonly string UrlCEP = "https://ws.hubdodesenvolvedor.com.br/v2/cep3/?cep={0}&token={1}";
        internal string GetUrlCNPJ(string cnpj, string token)
        {
            return string.Format(UrlCNPJ, cnpj, token);
        }
        internal string GetUrlCPF(string cpf, DateTime birthdata, string token)
        {
            return string.Format(UrlCPF, cpf, birthdata.ToString("dd-MM-yyyy"), token);
        }
        internal string GetUrlCEP(string zip, string token)
        {
            return string.Format(UrlCEP, zip, token);
        }

        private UrlAddress() { }

        private static readonly object _lock = new object();
        private static UrlAddress _instance;

        public static UrlAddress Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UrlAddress();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
