
using Frontend.Models;
using Frontend.Models.ViewModel;
using Frontend.Service;
using Microsoft.AspNetCore.Mvc;
using TestApp.Infrostructures.DataTable;
using TestApp.Infrostructures.Select2;



namespace Frontend.Controllers
{

    public class GroupController : Controller
    {
        private readonly IGroupService _apiService;
        public GroupController(IGroupService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> GroupIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateGroup([FromBody] GroupDto group)
        {
            var result = await _apiService.CreateGroup(group);
            return new JsonResult(new { Message = $"Group {group.GroupName} created " });
        }
        [HttpPost]
        public async Task<JsonResult> GetTable(DataTableSearchModel dataTableSearchModel)
        {
            var result = await _apiService.GetAllDataTable(dataTableSearchModel);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> GetAllCategories(Select2Request select2Request)
        {
            var result = await _apiService.GetAllSelect2Categories(select2Request);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEditGroup(int? id)
         {
            if (id == null)
            {
                return PartialView("_CreateEditGroup");
            }
            else
            {
                var group = await _apiService.GetGroupById(id);
                return PartialView("_CreateEditGroup", group);
            }
        }
        [HttpPost]
        public async Task<JsonResult> UpdateGroup([FromBody] Group group) 
        {
            var result = await _apiService.UpdateGroup(group);
            return new JsonResult(new { Message = $"Group {group.GroupName} edited " });
        }
    }
}
