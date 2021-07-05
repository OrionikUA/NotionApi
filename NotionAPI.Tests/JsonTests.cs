using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace NotionAPI.Tests
{
    [TestClass]
    public class JsonTests
    {
        [JsonParserTestCases]
        public void ParserTests(string file)
        {
            var text = File.ReadAllText(file);
            var obj = JsonParser.Parse(text);
            Assert.IsTrue(obj.HasNoWarnings("file"));
            Assert.IsTrue(obj.HasNoErrors("file"));
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ" });
            var newText = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            var textLines = text.Split("\n");
            var newTextLines = newText.Split("\n");
            for (int i = 0; i < textLines.Length; i++)
            {
                if (textLines[i].Contains("\"start\": \"20") || textLines[i].Contains("\"end\": \"20"))
                    continue;
                Assert.AreEqual(textLines[i], newTextLines[i], $"Line {i + 1}");
            }
        }

    }
}
