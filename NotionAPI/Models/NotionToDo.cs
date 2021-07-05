using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionToDo : NotionTexts
    {
        [JsonProperty("checked", Order = 1)]
        public bool Checked { get; set; }
    }
}
