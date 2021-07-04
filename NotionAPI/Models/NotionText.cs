using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionText : NotionObject, INotionType
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("text")]
        public NotionTextContent Text { get; set; }
        [JsonProperty("annotations")]
        public NotionAnnotations Annotations { get; set; }
        [JsonProperty("plain_text")]
        public string PlainText { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
