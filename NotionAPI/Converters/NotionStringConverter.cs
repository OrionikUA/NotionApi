using System;
using Newtonsoft.Json;
using NotionAPI.Models;

namespace NotionAPI.Converters
{
    public class NotionStringConverter : JsonConverter<NotionStringObject>
    {
        public override NotionStringObject ReadJson(JsonReader reader, Type objectType, NotionStringObject existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, NotionStringObject value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
