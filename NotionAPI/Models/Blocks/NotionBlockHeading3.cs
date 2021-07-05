using System.Collections.Generic;
using Newtonsoft.Json;
namespace NotionAPI.Models.Blocks
{
    public class NotionBlockHeading3 : NotionBlock
    {
        [JsonProperty("heading_3", Order = 6)]
        public NotionTexts Heading3 { get; set; }
    }
}
