using Newtonsoft.Json;

namespace NotionAPI.Models.PageData
{
    public class NotionPageSelectData : NotionObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
