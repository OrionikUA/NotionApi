using Newtonsoft.Json;

namespace NotionAPI.Models.Blocks
{
    public class NotionBlockToDo : NotionBlock
    {
        [JsonProperty("to_do", Order = 6)]
        public NotionToDo ToDo { get; set; }
    }
}
