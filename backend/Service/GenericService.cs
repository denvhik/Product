using Microsoft.EntityFrameworkCore;
using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Extensions;
using TestApp.Infrostructures.Select2;
using backend.Data;
using backend.Models;
using backend.Repository;
using backend.Models.ViewModel;

namespace backend.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
           
        }
        public async Task<T> AddAsync(T product)
        {
            
            await _genericRepository.AddAsync(product);
            await _genericRepository.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Product>> UnionAllAsync()
        {
            var products = await _genericRepository.GetQuery<Product>().Include(x => x.Group).ThenInclude(x => x.Category).ToListAsync();

            return products;

        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return (IEnumerable<Category>)await _genericRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Group>> GetAllGroupAsync()
        {
            return (IEnumerable<Group>)await _genericRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<T> UpdateAsync(T product)
        {

            return await _genericRepository.UpdateAsync(product);

        }
     

        public async Task<IEnumerable<Group>> UnionCategoryAndGroup()
        {
            var group = await _genericRepository.GetQuery<Group>().Include(x => x.Category).ToListAsync();
            return group;
        }

        public async Task<Select2Results> GetAllSelect2Categories(Select2Request request)
        {
            var query = _genericRepository.GetQuery<Category>().Distinct();
            if (!string.IsNullOrWhiteSpace(request.searchTerm))
            {
                query = query.Where(x => EF.Functions.Like(x.CategoryName, $"%{request.searchTerm.Trim()}%"));
                Console.WriteLine(query);
            
            }

            var total = query.Count();
            var more = total > request.pageSize * request.pageNum;
            var data = await query.OrderBy(i => i.CategoryId).Select(i => new Select2Item
            {
                id = i.CategoryId.ToString(),
                text = i.CategoryName,
                title = i.CategoryName,
            })
            .Skip(request.pageSize * (request.pageNum - 1))
            .Take(request.pageSize)
            .ToListAsync();
            return new Select2Results { results = data, more = more };

        }

        public async Task<DTResult<Group>> GetAllTableData(DataTableSearchModel dataTableSearchModel)
        {
            var items = _genericRepository.GetQuery<Group>();
            var sortCriterias = dataTableSearchModel.DTParameterModel.GetSortCriterias();
            items = sortCriterias != null ?
            items.OrderBy(sortCriterias) :
                items.OrderByDescending(i => i.GroupName);
            var count = items.Count();
            var search = new DTResult<Group>
            {
                data =
                       await (dataTableSearchModel.DTParameterModel.Length != -1
                            ? items.Skip(dataTableSearchModel.DTParameterModel.Start).Take(dataTableSearchModel.DTParameterModel.Length)
                            : items).Select(x => new Group()
                            {
                               
                                GroupName = x.GroupName,
                                GroupId = x.GroupId,
                                Category = x.Category,

                                
                            }).ToListAsync(),
                recordsTotal = count,
                recordsFiltered = count,
                draw = dataTableSearchModel.DTParameterModel.Draw
            };
            return search;
        }

        public async Task<DTResult<Category>> GetAllTableCategory(DataTableSearchModel dataTableSearchModel)
        {
            var items = _genericRepository.GetQuery<Category>();
            var sortCriterias = dataTableSearchModel.DTParameterModel.GetSortCriterias();
            items = sortCriterias != null ?
            items.OrderBy(sortCriterias) :
                items.OrderByDescending(i => i.CategoryName);
            var count = items.Count();
            var search = new DTResult<Category>
            {
                data =
                       await(dataTableSearchModel.DTParameterModel.Length != -1
                            ? items.Skip(dataTableSearchModel.DTParameterModel.Start).Take(dataTableSearchModel.DTParameterModel.Length)
                            : items).Select(x => new Category()
                            {
                                CategoryName = x.CategoryName,
                                CategoryId = x.CategoryId,
                            }).ToListAsync(),
                recordsTotal = count,
                recordsFiltered = count,
                draw = dataTableSearchModel.DTParameterModel.Draw
            };
            return search;
        }


    }
}
