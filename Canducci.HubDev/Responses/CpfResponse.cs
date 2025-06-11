using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class CpfResponse: BaseResponse<CpfItem>
    {
        [JsonConstructor()]
        public CpfResponse(bool status, string returnMessage, int consumed, CpfItem result)
            :base(status, returnMessage, consumed, result)
        {
        }
    }

}
