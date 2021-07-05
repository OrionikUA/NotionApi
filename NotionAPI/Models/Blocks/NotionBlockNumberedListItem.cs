using Newtonsoft.Json;

namespace NotionAPI.Models.Blocks
{
    public class NotionBlockNumberedListItem : NotionBlock
    {
        [JsonProperty("numbered_list_item", Order = 6)]
        public NotionTexts Texts { get; set; }
    }
}
