using System.Collections.Generic;
using Newtonsoft.Json;
using NotionAPI.Models.TextContainer;

namespace NotionAPI.Models
{
    public class NotionTexts : NotionObject
    {
        [JsonProperty("text", Order = 0)]
        [JsonConverter(typeof(ListToNotionObjectConverter<NotionTextContainer>))]
        public List<NotionTextContainer> Texts { get; set; } = new List<NotionTextContainer>();
    }
}
