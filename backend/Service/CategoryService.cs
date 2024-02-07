using backend.Models;
using backend.Models.ViewModel;
using backend.Repository;

namespace backend.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryService;
        public CategoryService(IGenericRepository<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task AddCategoryDTOAsync(CategoryDto categoryDto)
        {
            var groupDTO = new Category()
            {
                CategoryName = categoryDto.CategoryName,
            };
            await _categoryService.AddAsync(groupDTO);
        }


        public async Task UpdateCategoryDtoAsync(CategoryDto categoryDto)
        {
            var category = await _categoryService.GetByIdAsync(categoryDto.CategoryId);

            if (category is null) return;

            category.CategoryId = categoryDto.CategoryId;
            category.CategoryName = categoryDto.CategoryName;

            await _categoryService.UpdateAsync(category);
            await _categoryService.SaveChangesAsync();
        }

    }
}
