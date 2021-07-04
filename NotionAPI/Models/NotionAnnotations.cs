using System;
using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionAnnotations : NotionObject
    {
        [JsonProperty("bold")]
        public bool Bold { get; set; }
        [JsonProperty("italic")]
        public bool Italic { get; set; }
        [JsonProperty("strikethrough")]
        public bool Strikethrough { get; set; }
        [JsonProperty("underline")]
        public bool Underline { get; set; }
        [JsonProperty("code")]
        public bool Code { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
