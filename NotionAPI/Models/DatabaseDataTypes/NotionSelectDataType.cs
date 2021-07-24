using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NotionAPI.Models.DatabaseDataTypes.HelperTypes;

namespace NotionAPI.Models.DatabaseDataTypes
{
    public class NotionSelectDataType : NotionDatabaseBaseDataType
    {
        [JsonProperty("options")]
        public List<NotionOptionConfig> Options { get; set; } = new List<NotionOptionConfig>();
    }
}
