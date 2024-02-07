using backend.Models.ViewModel;

namespace backend.Service
{
    public interface ICategoryService
    {
        Task  AddCategoryDTOAsync(CategoryDto categoryDto);
        Task UpdateCategoryDtoAsync(CategoryDto product);
    }
    
}

