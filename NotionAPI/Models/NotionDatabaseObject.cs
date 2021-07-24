using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NotionAPI.Converters;
using NotionAPI.Models.TextContainer;

namespace NotionAPI.Models
{
    public class NotionDatabaseObject: NotionObject, INotionObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }
        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }
        [JsonProperty("title")]
        [JsonConverter(typeof(ListToNotionObjectConverter<NotionTextContainer>))]
        public List<NotionTextContainer> Text { get; set; } = new List<NotionTextContainer>();
        [JsonProperty("properties")]
        [JsonConverter(typeof(DatabaseDataTypeContainerConverter))]
        public NotionDatabaseProperies Properties { get; set; }
        [JsonProperty("parent")]
        [JsonConverter(typeof(StringToNotionObjectConverter<NotionObject>))]
        public NotionObject Parent { get; set; }
    }
}
