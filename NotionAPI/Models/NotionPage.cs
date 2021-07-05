using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionPage : NotionObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
