using System.Collections.Generic;
using NotionAPI.Models.PageData;

namespace NotionAPI.Models
{
    public class NotionPageProperties : NotionObject
    {
        public Dictionary<string, NotionPageDataContainer> Types { get; set; } = new Dictionary<string, NotionPageDataContainer>();
    }
}
