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
    public class GroupController : Controller
    {
        private readonly IGenericService<Category> _categoryService;
        private readonly IGenericService<Group> _groupGenericService;
        private readonly IGroupService _groupDtoService;
        public GroupController(IGenericService<Category> categoryservice, IGroupService groupDtoService, IGenericService<Group> groupGenericService)
        {
            _categoryService = categoryservice;
            _groupDtoService = groupDtoService;
            _groupGenericService = groupGenericService;
        }
        

        [HttpPost("/GetAllTableData1")]
        public async Task<ActionResult> GetAllTableData([FromBody] DataTableSearchModel dataTableSearchModel)
        {
            var result = await _groupGenericService.GetAllTableData(dataTableSearchModel);
            return Ok(result);
        }
        [HttpPost("/GetAllCategories")]
        public async Task<ActionResult> GetAllCategories([FromBody] Select2Request select2Request)
        {
            var categories = await _categoryService.GetAllSelect2Categories(select2Request);
            return Json(categories);
        }

        [HttpPost("/CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] GroupDto groupDto)
        { 
            
                await _groupDtoService.AddGroupDto(groupDto);
                return new JsonResult(new { Message = $"Group {groupDto.GroupName} created " });
          
        }

       

        [HttpPost("/UpdateGroup")]
        public async Task<IActionResult> UpdateGroup([FromBody] GroupDto groupdto)
        {
            await _groupDtoService.UpdateGroupDtoAsync(groupdto);
            return new JsonResult(new { Message = $"Group {groupdto.GroupName} Edited " });
        }

        [HttpPost("/GetById")]
        public async Task<ActionResult> GetGroupById([FromBody] int? id )
        {
            var group = await _groupGenericService.GetByIdAsync(id);
            return Json(group);
        }

    }
}
