using Newtonsoft.Json;

namespace NotionAPI.Models.Blocks
{
    public class NotionBlockUnsupported : NotionBlock
    {
        [JsonProperty("unsupported", Order = 6)]
        public object Unsupported { get; set; }
    }
}
