using Newtonsoft.Json;
namespace NotionAPI.Models.Blocks
{
    public class NotionBlockBulletedListItem : NotionBlock
    {
        [JsonProperty("bulleted_list_item", Order = 6)]
        public NotionTexts Texts { get; set; }
    }
}
