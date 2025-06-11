using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{  
    public class ZipCodeResponse: BaseResponseAbstract<ZipCodeItem>
    {
        [JsonConstructor()]
        public ZipCodeResponse(bool status, string returnMessage, int consumed, ZipCodeItem result)
            :base(status, returnMessage, consumed, result)
        {
        }
    }
}
