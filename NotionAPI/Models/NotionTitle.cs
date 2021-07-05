using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NotionAPI.Models.TextContainer;

namespace NotionAPI.Models
{
    public class NotionTitle : NotionObject, INotionType
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }        
        [JsonProperty("title")]
        [JsonConverter(typeof(ListToNotionObjectConverter<NotionTextContainer>))]
        public List<NotionTextContainer> Title { get; set; } = new List<NotionTextContainer>();
    }
}
