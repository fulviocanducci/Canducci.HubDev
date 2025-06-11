using Newtonsoft.Json;
using System.Collections.Generic;
namespace Canducci.HubDev.Responses
{
    public class StateRegistrationItem
    {
        [JsonConstructor()]
        public StateRegistrationItem(string @return, string originIE, string lastUpdate, List<StateIeEntryItem> otherIes)
        {
            Return = @return;
            OriginIE = originIE;
            LastUpdate = lastUpdate;
            OtherIes = otherIes;
        }

        [JsonProperty("return")]
        public string Return { get; private set; }

        [JsonProperty("ie_uf_origem")]
        public string OriginIE { get; private set; }

        [JsonProperty("ie_last_update")]
        public string LastUpdate { get; private set; }

        [JsonProperty("outras_ies")]
        public List<StateIeEntryItem> OtherIes { get; private set; } = new List<StateIeEntryItem>();
    }

}
