using System;
using Newtonsoft.Json;

namespace NotionAPI.Models.PageData
{
    public class NotionPageDataContainer : NotionObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonIgnore]
        public NotionObject Data { get; set; }
    }
}
