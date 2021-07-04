using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NotionAPI.Models
{
    public abstract class NotionObject
    {
        public NotionObject()
        {
            _additionalData = new Dictionary<string, JToken>();
        }

        [JsonExtensionData]
        internal IDictionary<string, JToken> _additionalData;
    }
}
