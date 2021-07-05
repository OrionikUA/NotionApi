using System;
using Newtonsoft.Json;

namespace NotionAPI.Models.Blocks
{
    public class NotionBlock : NotionObject, INotionObject, INotionType
    {
        [JsonProperty("object", Order = 0)]
        public string Object { get; set; }
        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }
        [JsonProperty("created_time", Order = 2)]
        public DateTime CreatedTime { get; set; }
        [JsonProperty("last_edited_time", Order = 3)]
        public DateTime LastEditedTime { get; set; }
        [JsonProperty("has_children", Order = 4)]
        public bool HasChildren { get; set; }
        [JsonProperty("type", Order = 5)]
        public string Type { get; set; }
    }
}
