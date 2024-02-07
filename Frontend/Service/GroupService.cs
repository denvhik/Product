using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Frontend.Service.CustomHttpClients;
using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;
using Frontend.Models.ViewModel;

namespace Frontend.Service
{
    public class GroupService : IGroupService
    {
        private readonly IConfiguration _configuration;
        private readonly CustomHttpClient _customHttpClient;
        public GroupService(IConfiguration config, CustomHttpClient customHttpClient )
        {
            _customHttpClient = customHttpClient;
            _configuration = config;
        }

        public async Task<DTResult<Group>>  GetAllDataTable(DataTableSearchModel dataTableSearchModel)
        {
            using var response = await _customHttpClient.PostAsync("/GetAllTableData1", dataTableSearchModel);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result =  JsonSerializer.Deserialize<DTResult<Group>>(responseData,options);

            return result;

        }

        public async Task<Select2Results> GetAllSelect2Categories(Select2Request request)
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

        public async Task<Group> GetGroupById(int? id)
        {
            using var response = await _customHttpClient.PostAsync("/GetById", id);
            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<Group>(responseData, options);
            return result;
        }


        public  async Task<GroupDto> CreateGroup(GroupDto groupDto)
        {
            using var response = await _customHttpClient.PostAsync("/CreateGroup", groupDto);
            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<GroupDto>(responseData, options);
            return result;
        }

        public async Task<Group> UpdateGroup(Group groupdto)
        {
            using var response = await _customHttpClient.PostAsync("/UpdateGroup", groupdto);
            var responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<Group>( responseData, options);
            return result;
        }
    }
}
