using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionPageProperties : NotionObject
    {
        [JsonProperty("title")]
        public NotionTitle Title { get; set; }
    }
}
