using Frontend.Models;
using Frontend.Models.ViewModel;
using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;

namespace Frontend.Service
{
    public interface ICategoryService
    {
        public Task<DTResult<Category>> GetAllCategory(DataTableSearchModel dataTableSearchModel);
        Task<Select2Results> GetAllSelect2Categories(Select2Request request);
        Task<Category> GetCategoryById(int? id);
        public Task<CategoryDTO> CreateCategory(CategoryDTO groupDto);
        public Task<Category> UpdateCategory(Category group);
    }
}
