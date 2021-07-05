using System;
using Newtonsoft.Json;

namespace NotionAPI.Models.TextContainer
{
    public class NotionTextContainerText : NotionTextContainer
    {
        [JsonProperty("text", Order = 1)]
        public NotionTextContent Text { get; set; }
    }
}
