using Frontend.Models;
using Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;

namespace Frontend.Service
{
    public interface IGroupService
    {
        public Task<DTResult<Group>> GetAllDataTable(DataTableSearchModel dataTableSearchModel);
        Task<Select2Results> GetAllSelect2Categories(Select2Request request);
        Task<Group> GetGroupById(int? id);
        public  Task<GroupDto> CreateGroup(GroupDto groupDto);
        public  Task<Group> UpdateGroup(Group group);
    }
}
