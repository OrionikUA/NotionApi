using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;

namespace NotionAPI
{
    public static class JsonParser
    {
        public static NotionObject Parse(string text)
        {
            var obj = JObject.Parse(text); // TODO Exc
            var type = (string)obj["object"]; // TODO Exc
            return ParseByType(type, text);
        }

        public static NotionObject InnerParse(string text)
        {
            var obj = JObject.Parse(text); // TODO Exc
            var type = (string)obj["type"]; // TODO Exc
            return ParseByType(type, text);            
        }

        private static NotionObject ParseByType(string type, string text)
        {
            switch (type)
            {
                case "page": return JsonConvert.DeserializeObject<NotionPage>(text);
                case "error": return JsonConvert.DeserializeObject<NotionError>(text);
                case "page_id": return JsonConvert.DeserializeObject<NotionPageId>(text);
                case "text": return JsonConvert.DeserializeObject<NotionText>(text);
                default: return new NotionClientError();
            }
        }
    }
}
