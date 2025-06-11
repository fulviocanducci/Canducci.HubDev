using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{  
    public class ZipCodeResponse
    {
        [JsonConstructor()]
        public ZipCodeResponse(bool status, string returnMessage, int consumed, ZipCodeItem result)
        {
            Status = status;
            ReturnMessage = returnMessage;
            Consumed = consumed;
            Result = result;
        }

        [JsonProperty("status")]
        public bool Status { get; private set; }

        [JsonProperty("return")]
        public string ReturnMessage { get; private set; }

        [JsonProperty("consumed")]
        public int Consumed { get; private set; }

        [JsonProperty("result")]
        public ZipCodeItem Result { get; private set; }
    }
}
