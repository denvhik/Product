using Frontend.Models;
using Frontend.Models.ViewModel;
using Frontend.Service.CustomHttpClients;
using System.Text.Json;
using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;

namespace Frontend.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IConfiguration _configuration;
        private readonly CustomHttpClient _customHttpClient;
        public CategoryService(IConfiguration config, CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
            _configuration = config;
        }

        public async  Task<CategoryDTO> CreateCategory(CategoryDTO groupDto)
        {
            using var response = await _customHttpClient.PostAsync("/CreateCategory", groupDto);
            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<CategoryDTO>(responseData, options);
            return result;
        }

        public  async Task<DTResult<Category>> GetAllCategory(DataTableSearchModel dataTableSearchModel)
        {
            using var response = await _customHttpClient.PostAsync("/GetAllTableData", dataTableSearchModel);

            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<DTResult<Category>>(responseData, options);

            return result;
        }

        public async  Task<Select2Results> GetAllSelect2Categories(Select2Request request)
        {
            using var response = await _customHttpClient.PostAsync("/GetAllCategories", request);
            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<Select2Results>(responseData, options);
            return result;
        }

        public  async Task<Category> GetCategoryById(int? id)
        {
            using var response = await _customHttpClient.PostAsync("/GetCategoryById", id);
            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<Category>(responseData, options);
            return result;
        }

        public  async Task<Category> UpdateCategory(Category category)
        {
            using var response = await _customHttpClient.PostAsync("/UpdateCategory", category);
            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<Category>(responseData, options);
            return result;
        }
    }
}
