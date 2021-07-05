using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;

namespace NotionAPI
{
    public class StringToNotionObjectConverter<T> : JsonConverter<T> where T : NotionObject
    {
        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var obj = JsonParser.Parse(jObject.ToString());
            return (T)obj;
        }

        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
