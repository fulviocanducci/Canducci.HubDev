using System.Collections.Generic;
namespace Canducci.HubDev.Responses
{
    public class BalanceResponse : BaseResponseAbstract<List<List<BalanceItem>>>
    {
        public BalanceResponse(bool status, string returnMessage, int consumed, List<List<BalanceItem>> result) 
            : base(status, returnMessage, consumed, result)
        {
        }
    }

}
