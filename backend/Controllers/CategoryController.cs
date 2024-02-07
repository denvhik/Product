using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;
using backend.Models;
using backend.Models.ViewModel;
using backend.Service;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController:Controller
    {
        private readonly IGenericService<Category> _categoryService;
        private readonly ICategoryService _categoryDTOService;
        
        

        public CategoryController(IGenericService<Category> categoryservice,ICategoryService categoryService)
        {
            _categoryService = categoryservice;
            _categoryDTOService = categoryService;

        }

        [HttpPost("/GetAllTableData")]
        public async Task<ActionResult> GetAllTableData([FromBody] DataTableSearchModel dataTableSearchModel)
        {
            var result = await _categoryService.GetAllTableCategory(dataTableSearchModel);
            return Ok(result);
        }


        [HttpPost("/CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto category)
        {
            await _categoryDTOService.AddCategoryDTOAsync(category);

            return new JsonResult(new { Message = $"Category {category.CategoryName} created " });
        }

        

        [HttpPost("/UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto categoryDTO)
        {
            await _categoryDTOService.UpdateCategoryDtoAsync(categoryDTO);
            return new JsonResult(new { Message = $"Category {categoryDTO.CategoryName} Edited " });
        }

        [HttpPost("/GetCategoryById")]
        public async Task<ActionResult> GetCategroyById([FromBody] int? id)
        {
            var group = await _categoryService.GetByIdAsync(id);
            return Json(group);
        }

    }
}

