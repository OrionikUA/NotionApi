using Newtonsoft.Json;

namespace NotionAPI.Models.DatabaseDataTypes
{    
    public class NotionDatabaseDataTypeContainer : NotionObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonIgnore]
        public NotionDatabaseBaseDataType Data { get; set; }
    }
}
