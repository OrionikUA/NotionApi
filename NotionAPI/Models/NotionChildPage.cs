using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionChildPage : NotionObject
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
