using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class CpfPlusResponse : BaseResponseAbstract<PersonItem>
    {
        [JsonConstructor()]
        public CpfPlusResponse(bool status, string returnMessage, int consumed, PersonItem result)
            : base(status, returnMessage, consumed, result)
        {
        }
    }
}
