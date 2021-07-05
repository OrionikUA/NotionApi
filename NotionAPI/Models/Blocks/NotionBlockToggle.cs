using Newtonsoft.Json;

namespace NotionAPI.Models.Blocks
{
    public class NotionBlockToggle : NotionBlock
    {
        [JsonProperty("toggle", Order = 6)]
        public NotionTexts Texts { get; set; }
    }
}
