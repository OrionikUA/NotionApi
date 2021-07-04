using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionTitle : NotionObject, INotionType
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }        
        [JsonProperty("title")]
        [JsonConverter(typeof(ListToNotionObjectConverter))]
        public List<NotionObject> Title { get; set; } = new List<NotionObject>();
    }
}
