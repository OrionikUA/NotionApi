using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;
using NotionAPI.Models.Blocks;
using NotionAPI.Models.Mention;
using NotionAPI.Models.TextContainer;

namespace NotionAPI
{
    public static class JsonParser
    {
        public static NotionObject Parse(string text)
        {
            var obj = JObject.Parse(text);
            string type = null;
            if (obj.ContainsKey("type"))
            {
                type = (string)obj["type"];
            }
            if (obj.ContainsKey("object"))
            {
                var objectType = (string)obj["object"];
                return ParseByObject(objectType, type, text);
            }
            if (type != null)
            {
                return ParseByType(type, text);
            }
            return new NotionClientError();
        }

        private static NotionObject ParseByType(string type, string text)
        {
            switch (type)
            {
                case "page_id": return JsonConvert.DeserializeObject<NotionPageId>(text);
                case "text": return JsonConvert.DeserializeObject<NotionTextContainerText>(text);
                case "equation": return JsonConvert.DeserializeObject<NotionTextContainerEquation>(text);
                case "mention": return JsonConvert.DeserializeObject<NotionTextContainerMention>(text);
                case "paragraph": return JsonConvert.DeserializeObject<NotionBlockParagraph>(text);
                case "child_page": return JsonConvert.DeserializeObject<NotionBlockChildPage>(text);
                case "to_do": return JsonConvert.DeserializeObject<NotionBlockToDo>(text);
                case "heading_1": return JsonConvert.DeserializeObject<NotionBlockHeading1>(text);
                case "heading_2": return JsonConvert.DeserializeObject<NotionBlockHeading2>(text);
                case "heading_3": return JsonConvert.DeserializeObject<NotionBlockHeading3>(text);
                case "bulleted_list_item": return JsonConvert.DeserializeObject<NotionBlockBulletedListItem>(text);
                case "numbered_list_item": return JsonConvert.DeserializeObject<NotionBlockNumberedListItem>(text);
                case "toggle": return JsonConvert.DeserializeObject<NotionBlockToggle>(text);
                case "unsupported": return JsonConvert.DeserializeObject<NotionBlockUnsupported>(text);
                case "user": return JsonConvert.DeserializeObject<NotionMentionUser>(text);
                case "date": return JsonConvert.DeserializeObject<NotionMentionDate>(text);
                case "page": return JsonConvert.DeserializeObject<NotionMentionPage>(text);
                
                default: return new NotionClientError();
            }
        }

        private static NotionObject ParseByObject(string objectType, string type, string text)
        {
            switch (objectType)
            {
                case "page": return JsonConvert.DeserializeObject<NotionPageObject>(text);
                case "error": return JsonConvert.DeserializeObject<NotionError>(text);
                case "list": return JsonConvert.DeserializeObject<NotionList>(text);
                case "block": return type != null ? ParseByType(type, text) : JsonConvert.DeserializeObject<NotionBlock>(text);
                default: return new NotionClientError();
            }
        }
    }
}
