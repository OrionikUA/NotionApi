using NotionAPI.Models;

namespace NotionAPI.Console
{
    internal class Program
    {
        private const string Key = "";
        
        static void Main(string[] args)
        {
            var client = new NotionApiClient(Key);
            var page = client.RetrievePage("adfb9cdbd141414fa6dfd37047d0d19f").Result;

            page.WriteErrorsAndWarnings("page");

            //System.Console.WriteLine(page);
            System.Console.ReadLine();
        }
    }
}
