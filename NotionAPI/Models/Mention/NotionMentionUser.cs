using Newtonsoft.Json;
using NotionAPI.Models.User;

namespace NotionAPI.Models.Mention
{
    public class NotionMentionUser : NotionMention
    {
        [JsonProperty("user", Order = 1)]
        [JsonConverter(typeof(StringToNotionObjectConverter<NotionUser>))]
        public NotionUser User { get; set; }
    }
}
