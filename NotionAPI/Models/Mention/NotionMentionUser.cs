using Newtonsoft.Json;

namespace NotionAPI.Models.Mention
{
    public class NotionMentionUser : NotionMention
    {
        [JsonProperty("user", Order = 1)]
        public NotionUser User { get; set; }
    }
}
