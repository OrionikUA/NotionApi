using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionEquation : NotionObject
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }
    }
}
