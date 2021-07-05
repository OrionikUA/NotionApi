using Newtonsoft.Json;

namespace NotionAPI.Models.Mention
{
    public class NotionMentionPage : NotionMention
    {
        [JsonProperty("page", Order = 1)]
        public NotionPage Page { get; set; }
    }
}
