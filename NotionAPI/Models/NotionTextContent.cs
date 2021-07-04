using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionTextContent : NotionObject
    {
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
