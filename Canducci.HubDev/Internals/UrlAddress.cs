using System;
namespace Canducci.HubDev.Internals
{
    internal class UrlAddress
    {
        private const string UrlBase = "https://ws.hubdodesenvolvedor.com.br/v2/";
        private const string UrlCNPJ = "cnpj/?cnpj={0}&token={1}";
        private const string UrlCNPJWithIE = "cnpj/?cnpj={0}&token={1}&ie=1";
        private const string UrlCPF = "cpf/?cpf={0}&data={1}&token={2}";
        private const string UrlCPFPlus = "cadastropf/?cpf={0}&token={1}";
        private const string UrlZip = "cep3/?cep={0}&token={1}";
        private const string UrlBalance = "saldo?info&token={0}";
        internal string ConcateUrl(string url)
        {
            return UrlBase + url;
        }
        internal string GetUrlCNPJ(string cnpj, string token)
        {
            return string.Format(ConcateUrl(UrlCNPJ), cnpj, token);
        }
        internal string GetUrlCNPJWithIE(string cnpj, string token)
        {
            return string.Format(ConcateUrl(UrlCNPJWithIE), cnpj, token);
        }
        internal string GetUrlCPF(string cpf, DateTime birthdata, string token)
        {
            return string.Format(ConcateUrl(UrlCPF), cpf, birthdata.ToString("dd-MM-yyyy"), token);
        }
        internal string GetUrlCPFPlus(string cpf, string token)
        {
            return string.Format(ConcateUrl(UrlCPFPlus), cpf, token);
        }
        internal string GetUrlZip(string zip, string token)
        {
            return string.Format(ConcateUrl(UrlZip), zip, token);
        }
        internal string GetUrlBalance(string token)
        {
            return string.Format(ConcateUrl(UrlBalance), token);
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
