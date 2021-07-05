using System;
using Newtonsoft.Json;
using NotionAPI.Models.Mention;

namespace NotionAPI.Models.TextContainer
{
    public class NotionTextContainerMention : NotionTextContainer
    {
        [JsonProperty("mention", Order = 1)]
        [JsonConverter(typeof(StringToNotionObjectConverter<NotionMention>))]
        public NotionMention Mention { get; set; }
    }
}
