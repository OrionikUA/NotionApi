using Newtonsoft.Json;

namespace NotionAPI.Models.DatabaseDataTypes
{
    public class NotionFormulaDataType : NotionDatabaseBaseDataType
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }
    }
}
