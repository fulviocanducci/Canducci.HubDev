using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{  
    public class ZipResponse: BaseResponseAbstract<ZipCodeItem>
    {
        [JsonConstructor()]
        public ZipResponse(bool status, string returnMessage, int consumed, ZipCodeItem result)
            :base(status, returnMessage, consumed, result)
        {
        }
    }
}
