using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionPerson : NotionObject
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
