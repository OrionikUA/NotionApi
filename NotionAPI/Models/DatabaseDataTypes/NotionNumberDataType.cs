using Newtonsoft.Json;

namespace NotionAPI.Models.DatabaseDataTypes
{
    public class NotionNumberDataType : NotionDatabaseBaseDataType
    {
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
