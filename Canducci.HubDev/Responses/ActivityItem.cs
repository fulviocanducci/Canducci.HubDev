using Newtonsoft.Json;
namespace Canducci.HubDev.Responses
{
    public class ActivityItem
    {
        [JsonConstructor()]
        public ActivityItem(string description, string code)
        {
            Description = description;
            Code = code;
        }

        [JsonProperty("text")]
        public string Description { get; private set; }

        [JsonProperty("code")]
        public string Code { get; private set; }
    }

}
