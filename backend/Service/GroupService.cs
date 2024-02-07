using backend.Models.ViewModel;
using backend.Repository;
using backend.Models;

namespace backend.Service
{
    public class GroupService : IGroupService
    {
        
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<GroupDto> _groupDTORepository;

        public GroupService(IGenericRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task AddGroupDto(GroupDto? group)
        {

            var groupDTO = new Group()
            {
                GroupName = group.GroupName,
                CategoryId = group.CategoryId,
            };
            await _groupRepository.AddAsync(groupDTO);
        }

        public async Task<IEnumerable<Group>> GetAllGroupAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task UpdateGroupDtoAsync(GroupDto groupDto)
        {
            var group = await _groupRepository.GetByIdAsync(groupDto.GroupId);
            
            if (group is null) return;

            group.CategoryId = groupDto.CategoryId;
            group.GroupName = groupDto.GroupName;
            
            await _groupRepository.UpdateAsync(group);
            await _groupRepository.SaveChangesAsync();    
        }

       
    }
}
