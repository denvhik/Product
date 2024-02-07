using TestApp.Infrostructures.DataTable;
using backend.Models;
using backend.Models.ViewModel;

namespace backend.Service
{
    public interface IGroupService
    {
     
        Task<IEnumerable<Group>> GetAllGroupAsync();
        Task AddGroupDto(GroupDto groupDto);
        Task UpdateGroupDtoAsync(GroupDto product);
    }
}
