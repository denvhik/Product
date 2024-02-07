using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;
using backend.Models;
using backend.Models.ViewModel;

namespace backend.Service
{
    public interface IGenericService<T> where T : class
    {
        Task<Select2Results> GetAllSelect2Categories(Select2Request request);
        Task<DTResult<Group>> GetAllTableData(DataTableSearchModel dataTableSearchModel);
        Task<DTResult<Category>> GetAllTableCategory(DataTableSearchModel dataTableSearchModel);
        Task<IEnumerable<Product>> UnionAllAsync();
        Task<IEnumerable<Group>> UnionCategoryAndGroup();
     
        Task<IEnumerable<Category>> GetAllCategoryAsync();
       
        Task<T> AddAsync(T product);
        Task<T> GetByIdAsync(int? id);
        Task<T> UpdateAsync(T product);
   
        Task<bool> DeleteAsync(int id);
    }
}
