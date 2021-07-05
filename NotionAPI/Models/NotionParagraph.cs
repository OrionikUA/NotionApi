using System.Collections.Generic;
using Newtonsoft.Json;
using NotionAPI.Models.TextContainer;

namespace NotionAPI.Models
{
    public class NotionParagraph : NotionObject
    {
        [JsonProperty("text")]
        [JsonConverter(typeof(ListToNotionObjectConverter<NotionTextContainer>))]
        public List<NotionTextContainer> Text { get; set; } = new List<NotionTextContainer>();
    }
}
