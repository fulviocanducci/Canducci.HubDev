using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class StateIeEntryItem
    {
        [JsonConstructor()]
        public StateIeEntryItem(string state, string number, string activated)
        {
            State = state;
            Number = number;
            Activated = activated;
        }

        [JsonProperty("uf")]
        public string State { get; private set; }

        [JsonProperty("numero")]
        public string Number { get; private set; }

        [JsonProperty("ativado")]
        public string Activated { get; private set; }
    }
}
