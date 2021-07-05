using Newtonsoft.Json;

namespace NotionAPI.Models.Blocks
{
    public class NotionBlockChildPage : NotionBlock
    {
        [JsonProperty("child_page", Order = 6)]
        public NotionChildPage ChildPage { get; set; }
    }
}
