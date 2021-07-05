using System.Collections.Generic;
using Newtonsoft.Json;
namespace NotionAPI.Models.Blocks
{
    public class NotionBlockHeading1 : NotionBlock
    {
        [JsonProperty("heading_1", Order = 6)]
        public NotionTexts Heading1 { get; set; }
    }
}
