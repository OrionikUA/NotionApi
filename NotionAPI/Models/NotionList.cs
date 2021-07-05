using System.Collections.Generic;
using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionList : NotionObject, INotionObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("results")]
        [JsonConverter(typeof(ListToNotionObjectConverter<NotionObject>))]
        public List<NotionObject> Results { get; set; } = new List<NotionObject>();
        [JsonProperty("next_cursor")]
        public NotionObject NextCursor { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
    }
}
