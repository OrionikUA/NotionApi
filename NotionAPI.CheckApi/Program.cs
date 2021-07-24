using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotionAPI.CheckApi
{
    class Program
    {
        private static string Key => Environment.GetEnvironmentVariable("NotionAPIKey");
        private static HttpClient Client;

        private static Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            ["RetrieveEveryBlockFromSimplePageTest1.json"] = "https://api.notion.com/v1/blocks/0d8382e6781240e48a05bce6bbc6c305/children?page_size=100",
            ["RetrieveEveryBlockFromSimplePageTest2.json"] = "https://api.notion.com/v1/blocks/6c47b70fd5494758ba194f9d448b5d44/children?page_size=100",
            ["RetrieveAPageTest1.json"] = "https://api.notion.com/v1/pages/6c47b70fd5494758ba194f9d448b5d44",
            ["ErrorPageTest1.json"] = "https://api.notion.com/v1/pages/6c47b70fd5494758ba194f9d448b5d43",
            ["RetrieveAUserTest1.json"] = "https://api.notion.com/v1/users/4b7a02f8-30b0-47c3-8ff4-5c1c6d2f1e41",
            ["ListAllUsersTest1.json"] = "https://api.notion.com/v1/users",
            ["RetrieveInformationAboutDatabaseTest1.json"] = "https://api.notion.com/v1/databases/e5f8b18265864cd3a99f239e0db6da6c",
            ["RetrieveInformationAboutDatabaseTest2.json"] = "https://api.notion.com/v1/databases/076f337369214b33a43514dc7838e3b0",
        };

        private static void Main(string[] args)
        {
            Console.Write("Start. ");
            var solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var testProjectPath = Path.Combine(solutiondir, "NotionAPI.Tests");
            var testFilesPath = Path.Combine(testProjectPath, "TestFiles");
            var testFiles = Directory.GetFiles(testFilesPath);

            Client = (new NotionApiClient(Key)).Client;

            Console.Write($"Files: ");

            var endCursor = Console.GetCursorPosition();
            var cursor = Console.GetCursorPosition();
            for (int i = 0; i < testFiles.Length; i++)
            {
                Console.SetCursorPosition(cursor.Left, cursor.Top);
                Console.Write($"({i + 1}/{testFiles.Length})");
                Console.SetCursorPosition(endCursor.Left, endCursor.Top);

                string filePath = testFiles[i];
                var fileName = Path.GetFileName(filePath);
                if (dictionary.ContainsKey(fileName))
                {
                    Analyse(filePath, dictionary[fileName]);
                }
                else
                {
                    Console.Write($"\n!Cannot find Url for file {fileName}. ");
                }
                endCursor = Console.GetCursorPosition();                
            }
            Console.Write("\nEnd Results.");
            Console.ReadLine();
        }

        private static void Analyse(string filePath, string url)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var extension = Path.GetExtension(filePath);
            var responce = PrettyJson(GetContentAsync(url).Result);            
            var file = PrettyJson(File.ReadAllText(filePath));
            var responceLines = responce.Split("\n");
            var fileLines = file.Split("\n");
            var count = Math.Min(responceLines.Length, fileLines.Length);
            for (int i = 0; i < count; i++)
            {
                if (fileLines[i] != responceLines[i])
                {
                    Console.Write($"\n!{fileName} has differences! it starts at line {i}.");
                    var directory = Path.GetDirectoryName(filePath);
                    var newFilePath = Path.Combine(directory, $"{fileName}_New{extension}");
                    File.WriteAllText(newFilePath, responce);
                    break;
                }
            }
        }

        private static async Task<string> GetContentAsync(string url)
        {
            var responce = await Client.GetAsync(url);
            return await responce.Content.ReadAsStringAsync();
        }

        public static string PrettyJson(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);
            var str = JsonSerializer.Serialize(jsonElement, options);
            str = str.Replace("\\u2192", "→");
            str = str.Replace("\\u002B", "+");
            str = str.Replace("\\u0060", "`");
            str = str.Replace("\\u003E", ">");
            return str;
        }
    }
}
