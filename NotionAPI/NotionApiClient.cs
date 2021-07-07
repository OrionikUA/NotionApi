using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NotionAPI.Models;

namespace NotionAPI
{
    public class NotionApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly UrlBuilderV1 _urlBuilder;

        public HttpClient Client => _httpClient;

        public NotionApiClient(string secretKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
            _httpClient.DefaultRequestHeaders.Add("Notion-Version", "2021-05-13");
            _urlBuilder = new UrlBuilderV1();
        }         

        public async Task<NotionObject> RetrievePage(string id)
        {
            var url = _urlBuilder.RetrievePageUrl(id);
            var responce = await _httpClient.GetAsync(url);
            var str = await responce.Content.ReadAsStringAsync();
            return JsonParser.Parse(str);
        }

        public async Task<NotionObject> RetrieveBlockChildren(string id)
        {
            var url = _urlBuilder.RetrieveBlockChildrenUrl(id);
            var responce = await _httpClient.GetAsync(url);
            var str = await responce.Content.ReadAsStringAsync();
            return JsonParser.Parse(str);
        }        
    }
}

