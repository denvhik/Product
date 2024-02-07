using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using backend.Data;
using backend.Models;
using backend.Models.ViewModel;

namespace backend.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _DbSet;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _DbSet = _dataContext.Set<T>();
        }
        
        public async Task<T> GetByIdAsync(int? id)
        {
            var product = await _DbSet.FindAsync(id);

            return product;
        }
        public async Task<T> UpdateAsync(T product)
        {
            _DbSet.Update(product);
          
            await _dataContext.SaveChangesAsync();
            return product;
        }
        public async Task<T> AddAsync(T product)
        {

            
            await _DbSet.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }
        public async Task<T> DeleteAsync(int id)
        {
            var deleteuser = await _DbSet.FindAsync(id);
            _DbSet.Remove(deleteuser);
            await _dataContext.SaveChangesAsync();
            return deleteuser;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();

        }

        public IQueryable<T> GetQuery<T>() where T : class
        {
            return _dataContext.Set<T>();
        }

        public async Task SaveChangesAsync() => await _dataContext.SaveChangesAsync();
    }
}
