using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using TestApp.Infrostructures.DataTable;

namespace Frontend.Service.CustomHttpClients
{
    public class CustomHttpClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        
       
        public CustomHttpClient(HttpClient httpClient, IConfiguration configuration)
        {

            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> PostAsync(string url,object data)
        {
            var jsonContent = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
              return await _httpClient.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return _httpClient.GetAsync(url).Result;
        }
    }
}
