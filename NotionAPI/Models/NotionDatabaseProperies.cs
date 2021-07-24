using System.Collections.Generic;
using NotionAPI.Models.DatabaseDataTypes;

namespace NotionAPI.Models
{
    public class NotionDatabaseProperies: NotionObject
    {
        public Dictionary<string, NotionDatabaseDataTypeContainer> Types { get; set; } = new Dictionary<string, NotionDatabaseDataTypeContainer>();
    }
}
