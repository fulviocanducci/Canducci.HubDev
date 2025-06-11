namespace Canducci.HubDev.Responses
{
    public class CnpjResponse : BaseResponseAbstract<CnpjItem>
    {
        public CnpjResponse(bool status, string returnMessage, int consumed, CnpjItem result) : 
            base(status, returnMessage, consumed, result)
        {
        }
    }
}
