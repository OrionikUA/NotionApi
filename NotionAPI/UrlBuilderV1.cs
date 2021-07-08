using System.IO;
using System.Text;

namespace NotionAPI
{
    internal class UrlBuilderV1
    {
        private const string ApiVersion = "v1";
        private const string MainUrl = "https://api.notion.com";
        private const string PagesUrl = "pages";
        private const string UsersUrl = "users";
        private const string BlocksUrl = "blocks";
        private const string ChildrenUrl = "children?";
        private const string PageSizeParameter = "page_size";

        public string RetrieveUserUrl(string id) => Path.Combine(MainUrl, ApiVersion, UsersUrl, id);
        public string RetrieveUsersUrl() => Path.Combine(MainUrl, ApiVersion, UsersUrl);
        public string RetrievePageUrl(string id) => Path.Combine(MainUrl, ApiVersion, PagesUrl, id);
        public string RetrieveBlockChildrenUrl(string id) => Path.Combine(MainUrl, ApiVersion, BlocksUrl, id, ChildrenUrl);

        public string BuildPageSize(int pageSize = 100) => $"{PageSizeParameter}={pageSize}";

        public string BuildParameters(string url, params string[] parameters)
        {
            var builder = new StringBuilder(url);
            for (int i = 0; i < parameters.Length; i++)
            {
                builder.Append(i == 0 ? "?" : "&");
                builder.Append(parameters[i]);
            }
            return builder.ToString();
        }
        
        public UrlBuilderV1()
        {
            
        }
    }
}
