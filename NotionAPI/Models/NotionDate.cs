using System;
using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionDate : NotionObject
    {
        [JsonProperty("start")]
        public DateTime? Start { get; set; }
        [JsonProperty("end")]
        public DateTime? End { get; set; }
    }
}
