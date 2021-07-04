using System.IO;

namespace NotionAPI
{
    internal class UrlBuilderV1
    {
        private const string ApiVersion = "v1";
        private const string MainUrl = "https://api.notion.com";
        private const string PagesUrl = "pages";

        public string RetrievePageUrl(string id) => Path.Combine(MainUrl, ApiVersion, PagesUrl, id);

        public UrlBuilderV1()
        {
            
        }
    }
}
