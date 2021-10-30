using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;
using NotionAPI.Models.PageData;

namespace NotionAPI.Converters
{
    public class PageDataContainerConverterJsonConverter : JsonConverter<NotionPageProperties>
    {
        public override NotionPageProperties ReadJson(JsonReader reader, Type objectType, NotionPageProperties existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var list = new NotionPageProperties();
            foreach (var jItem in jObject)
            {
                if (jItem.Value == null)
                {
                    list._additionalData.Add(jItem.Key, jItem.Value);
                    continue;
                }

                var tmpObj = JsonConvert.DeserializeObject<NotionPageDataContainer>(jItem.Value.ToString());
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

        public override void WriteJson(JsonWriter writer, NotionPageProperties value, JsonSerializer serializer)
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

        private NotionObject ParseType(IDictionary<string, JToken> dict, string type)
        {
            if (!dict.ContainsKey(type))
                return null;
            var obj = dict[type];
            NotionObject endObj;

            try
            {
                switch (type)
                {
                    //TODO
                    default: return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            if (endObj != null)
                dict.Remove(type);
            return endObj;
        }
    }
}
