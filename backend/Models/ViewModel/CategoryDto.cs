using System.ComponentModel.DataAnnotations;

namespace backend.Models.ViewModel
{
    public class CategoryDto
    {

        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
