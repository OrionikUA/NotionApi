using Newtonsoft.Json;

namespace NotionAPI.Models.Mention
{
    public class NotionMentionDate : NotionMention
    {
        [JsonProperty("date", Order = 1)]
        public NotionDate Date { get; set; }
    }
}
