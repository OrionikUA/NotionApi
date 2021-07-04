using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionAPI.Models;

namespace NotionAPI
{
    public class StringToNotionObjectConverter : JsonConverter<NotionObject>
    {
        public override NotionObject ReadJson(JsonReader reader, Type objectType, NotionObject existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var obj = JsonParser.InnerParse(jObject.ToString());
            return obj;
        }

        public override void WriteJson(JsonWriter writer, NotionObject value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
