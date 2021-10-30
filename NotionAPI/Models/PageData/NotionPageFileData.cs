using Newtonsoft.Json;

namespace NotionAPI.Models.PageData
{
    public class NotionPageFileData : NotionObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
