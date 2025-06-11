using Newtonsoft.Json;

namespace Canducci.HubDev.Responses
{
    public abstract class BaseResponse<T>
    {
        protected BaseResponse(bool status, string returnMessage, int consumed, T result)
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
        public T Result { get; private set; }
    }
}
