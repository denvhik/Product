using System.Linq.Expressions;
using backend.Models;
using backend.Models.ViewModel;

namespace backend.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetQuery<T>() where T :class;
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id); 
        Task<T> UpdateAsync(T product);
        Task <T> AddAsync(T product);
        
        Task<T> DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
