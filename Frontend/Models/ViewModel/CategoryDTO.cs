using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.ViewModel
{
    public class CategoryDTO
    {

        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }
    }
}
