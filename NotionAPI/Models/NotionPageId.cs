using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionPageId : NotionObject, INotionType
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("page_id")]
        public string PageId { get; set; }

        public NotionPageId()
        {
        }
    }
}
