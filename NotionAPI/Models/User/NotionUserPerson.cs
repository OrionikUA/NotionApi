using Newtonsoft.Json;

namespace NotionAPI.Models.User
{
    public class NotionUserPerson : NotionUser
    {
        [JsonProperty("person", Order = 5)]
        public NotionPerson Person { get; set; }
    }
}
