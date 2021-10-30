using System;
using Newtonsoft.Json;

namespace NotionAPI.Models.PageData
{
    public class NotionPageDateData : NotionObject
    {
        [JsonProperty("start")]
        public DateTime? Start { get; set; }
        [JsonProperty("end")]
        public DateTime? End { get; set; }
    }
}
