using System;
using Newtonsoft.Json;

namespace NotionAPI.Models.DatabaseDataTypes.HelperTypes
{
    public class NotionOptionConfig : NotionObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
