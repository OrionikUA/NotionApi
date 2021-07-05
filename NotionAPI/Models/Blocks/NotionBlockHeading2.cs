using System.Collections.Generic;
using Newtonsoft.Json;
namespace NotionAPI.Models.Blocks
{
    public class NotionBlockHeading2 : NotionBlock
    {
        [JsonProperty("heading_2", Order = 6)]
        public NotionTexts Heading2 { get; set; }
    }
}
