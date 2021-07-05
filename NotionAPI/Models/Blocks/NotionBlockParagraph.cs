using Newtonsoft.Json;

namespace NotionAPI.Models.Blocks
{
    public class NotionBlockParagraph : NotionBlock
    {
        [JsonProperty("paragraph", Order = 6)]
        public NotionParagraph Paragraph { get; set; }
    }
}
