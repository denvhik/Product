using Frontend.Models;
using Frontend.Models.ViewModel;
using Frontend.Service;
using Microsoft.AspNetCore.Mvc;
using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;

namespace Frontend.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryservice)
        {
            _categoryService = categoryservice;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<JsonResult> GetAllCategory(DataTableSearchModel dataTableSearchModel)
        {
            var result = await _categoryService.GetAllCategory(dataTableSearchModel);
            return Json(result);
        }
        [HttpGet("/GetAllCategories")]
        public async Task<JsonResult> GetAllCategories(Select2Request select2Request)
        {
            var categories = await _categoryService.GetAllSelect2Categories(select2Request);
            return new JsonResult(categories);
        }

        [HttpPost]
        public async Task<JsonResult> CreateCategory([FromBody] CategoryDTO category)
        {
            await _categoryService.CreateCategory(category);

            return new JsonResult(new { Message = $"Category {category.CategoryName} created " });
        }

      

        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            await _categoryService.UpdateCategory(category);
            return new JsonResult(new { Message = $"Category {category.CategoryName} Edited " });
        }

        [HttpGet]
        public async Task<IActionResult> CreateEditCategory(int? id)
        {
            if (id == null)
            {
                return PartialView("_CreateEditCategory");
            }
            else
            {
                var category = await _categoryService.GetCategoryById(id);
                return PartialView("_CreateEditCategory", category);
            }
        }
    }
}
