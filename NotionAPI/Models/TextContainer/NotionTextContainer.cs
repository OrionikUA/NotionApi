using Newtonsoft.Json;

namespace NotionAPI.Models.TextContainer
{
    public class NotionTextContainer : NotionObject, INotionType
    {
        [JsonProperty("type", Order = 0)]
        public string Type { get; set; }        
        [JsonProperty("annotations", Order = 2)]
        public NotionAnnotations Annotations { get; set; }
        [JsonProperty("plain_text", Order = 3)]
        public string PlainText { get; set; }
        [JsonProperty("href", Order = 4)]
        public string Href { get; set; }
    }
}
