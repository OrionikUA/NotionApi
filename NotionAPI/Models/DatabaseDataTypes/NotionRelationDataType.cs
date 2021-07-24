using Newtonsoft.Json;

namespace NotionAPI.Models.DatabaseDataTypes
{
    public class NotionRelationDataType : NotionDatabaseBaseDataType
    {
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }
        [JsonProperty("synced_property_name")]
        public string SynncedPropertyName { get; set; }
        [JsonProperty("synced_property_id")]
        public string SyncedPropertyId { get; set; }
    }
}
