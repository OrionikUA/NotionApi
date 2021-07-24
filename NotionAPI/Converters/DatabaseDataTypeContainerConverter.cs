using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;
using NotionAPI.Models.DatabaseDataTypes;

namespace NotionAPI.Converters
{
    internal class DatabaseDataTypeContainerConverter: JsonConverter<NotionDatabaseProperies>
    {
        public override NotionDatabaseProperies ReadJson(JsonReader reader, Type objectType, NotionDatabaseProperies existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var list = new NotionDatabaseProperies();
            foreach (var jItem in jObject)
            {
                if (jItem.Value == null)
                {
                    list._additionalData.Add(jItem.Key, jItem.Value);
                    continue;
                }
                    

                var tmpObj = JsonConvert.DeserializeObject<NotionDatabaseDataTypeContainer>(jItem.Value.ToString());
                if (tmpObj == null || tmpObj.Type == null)
                {
                    list._additionalData.Add(jItem.Key, jItem.Value);
                    continue;
                }
                tmpObj.Data = ParseType(tmpObj._additionalData, tmpObj.Type);
                if (tmpObj.Data == null)
                {
                    list._additionalData.Add(jItem.Key, jItem.Value);
                    continue;
                }
                list.Types.Add(jItem.Key, tmpObj);
            }
            return list;
        }

        public override void WriteJson(JsonWriter writer, NotionDatabaseProperies value, JsonSerializer serializer)
        {
            var mainObj = new JObject();
            foreach (var item in value.Types)
            {
                var oneObj = JObject.FromObject(item.Value, serializer);
                oneObj.Add(item.Value.Type, JObject.FromObject(item.Value.Data));
                mainObj.Add(item.Key, oneObj);
            }
            foreach (var item in value._additionalData)
            {
                mainObj.Add(item.Key, item.Value);
            }
            mainObj.WriteTo(writer);
        }

        private NotionDatabaseBaseDataType ParseType(IDictionary<string, JToken> dict, string type)
        {
            if (!dict.ContainsKey(type))
                return null;
            var obj = dict[type];
            NotionDatabaseBaseDataType endObj;
            try
            {
                switch (type)
                {
                    case "relation": endObj = JsonConvert.DeserializeObject<NotionRelationDataType>(obj.ToString()); break;
                    case "select": endObj = JsonConvert.DeserializeObject<NotionSelectDataType>(obj.ToString()); break;
                    case "date": endObj = new NotionDatabaseBaseDataType(); break;
                    case "phone_number": endObj = new NotionDatabaseBaseDataType(); break;
                    case "number": endObj = JsonConvert.DeserializeObject<NotionNumberDataType>(obj.ToString()); break;
                    case "checkbox": endObj = new NotionDatabaseBaseDataType(); break;
                    case "multi_select": endObj = JsonConvert.DeserializeObject<NotionMultiSelectDataType>(obj.ToString()); break;
                    case "email": endObj = new NotionDatabaseBaseDataType(); break;
                    case "url": endObj = new NotionDatabaseBaseDataType(); break;
                    case "files": endObj = new NotionDatabaseBaseDataType(); break;
                    case "rich_text": endObj = new NotionDatabaseBaseDataType(); break;
                    case "people": endObj = new NotionDatabaseBaseDataType(); break;
                    case "title": endObj = new NotionDatabaseBaseDataType(); break;

                    case "rollup": endObj = JsonConvert.DeserializeObject<NotionRollupDataType>(obj.ToString()); break;
                    case "created_by": endObj = new NotionDatabaseBaseDataType(); break;
                    case "created_time": endObj = new NotionDatabaseBaseDataType(); break;
                    case "formula": endObj = JsonConvert.DeserializeObject<NotionFormulaDataType>(obj.ToString()); break;
                    case "last_edited_time": endObj = new NotionDatabaseBaseDataType(); break;
                    case "last_edited_by": endObj = new NotionDatabaseBaseDataType(); break;
                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
            if (endObj != null)
                dict.Remove(type);
            return endObj;
        }
    }
}
