using Newtonsoft.Json;

namespace NotionAPI.Models.Mention
{
    public class NotionMention : NotionObject, INotionType
    {
        [JsonProperty("type", Order = 0)]
        public string Type { get; set; }
    }
}
