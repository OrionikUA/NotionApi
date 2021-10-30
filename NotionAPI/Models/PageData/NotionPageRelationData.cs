using Newtonsoft.Json;

namespace NotionAPI.Models.PageData
{
    public class NotionPageRelationData : NotionObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
