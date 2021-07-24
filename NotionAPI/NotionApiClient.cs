using System;
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

        public async Task<NotionObject> RetrieveUser(string id)
        {
            var url = _urlBuilder.RetrieveUserUrl(id);
            var responce = await _httpClient.GetAsync(url);
            var str = await responce.Content.ReadAsStringAsync();
            return JsonParser.Parse(str);
        }

        public async Task<NotionObject> RetrieveUsers()
        {
            var url = _urlBuilder.RetrieveUsersUrl();
            var responce = await _httpClient.GetAsync(url);
            var str = await responce.Content.ReadAsStringAsync();
            return JsonParser.Parse(str);
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

        public async Task<NotionResult<NotionDatabaseObject>> RetrieveDatabaseInformationAsync(string databaseId)
        {
            var url = _urlBuilder.GetRetrieveInformationAboutDatabaseUrl(databaseId);
            return await GetAsync(url, obj => new NotionResult<NotionDatabaseObject>(obj));
        }

        private async Task<NotionResult<T>> GetAsync<T>(string url, Func<NotionObject, NotionResult<T>> creator) where T : NotionObject 
        {
            try
            {
                var responce = await _httpClient.GetAsync(url);
                var str = await responce.Content.ReadAsStringAsync();
                var obj = JsonParser.Parse(str);
                return creator(obj);
            }
            catch (Exception ex)
            {
                return creator(new NotionClientError(ex));
            }            
        }

    }
}

