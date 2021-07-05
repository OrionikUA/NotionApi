using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;

namespace NotionAPI
{
    public class ListToNotionObjectConverter<T> : JsonConverter<List<T>> where T : NotionObject
    {
        public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var list = new List<T>();
            JArray jArray = JArray.Load(reader);
            foreach (var jObject in jArray)
            {
                list.Add((T)JsonParser.Parse(jObject.ToString()));
            }
            
            return list;
        }

        public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
