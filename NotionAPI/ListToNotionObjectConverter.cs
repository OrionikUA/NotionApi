using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;

namespace NotionAPI
{
    public class ListToNotionObjectConverter : JsonConverter<List<NotionObject>>
    {
        public override List<NotionObject> ReadJson(JsonReader reader, Type objectType, List<NotionObject> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var list = new List<NotionObject>();
            JArray jArray = JArray.Load(reader);
            foreach (var jObject in jArray)
            {
                list.Add(JsonParser.InnerParse(jObject.ToString()));
            }
            
            return list;
        }

        public override void WriteJson(JsonWriter writer, List<NotionObject> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
