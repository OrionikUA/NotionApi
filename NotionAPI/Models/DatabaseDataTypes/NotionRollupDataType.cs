using Newtonsoft.Json;

namespace NotionAPI.Models.DatabaseDataTypes
{
    public class NotionRollupDataType : NotionDatabaseBaseDataType
    {
        [JsonProperty("rollup_property_name")]
        public string RollupName { get; set; }
        [JsonProperty("relation_property_name")]
        public string RelationName { get; set; }
        [JsonProperty("rollup_property_id")]
        public string RollupId { get; set; }
        [JsonProperty("relation_property_id")]
        public string RelationId { get; set; }
        [JsonProperty("function")]
        public string Function { get; set; }
    }
}
