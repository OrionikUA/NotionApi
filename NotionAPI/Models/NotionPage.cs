using System;
using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionPage: NotionObject, INotionObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }
        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }
        [JsonProperty("parent")]
        [JsonConverter(typeof(StringToNotionObjectConverter))]
        public NotionObject Parent { get; set; }
        [JsonProperty("archived")]
        public bool Archived { get; set; }
        [JsonProperty("properties")]
        public NotionPageProperties Properties { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        
    }
}
