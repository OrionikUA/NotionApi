using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionError : NotionObject, INotionObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
