using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
namespace Canducci.HubDev.Internals
{
    internal class HttpClient
    {
        internal HttpClient() { }

        private static readonly object _lock = new object();
        private static HttpClient _instance;

        public static HttpClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new HttpClient();
                        }
                    }
                }
                return _instance;
            }
        }

        public Task<string> GetStringAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEndAsync();
            }
        }

        public async Task<T> GetObjectAsync<T>(string url)
        {
            string json = await GetStringAsync(url);
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default;
        }
    }
}
