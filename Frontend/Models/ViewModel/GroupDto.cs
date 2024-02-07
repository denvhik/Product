using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.ViewModel
{
    public class GroupDto
    {

       
        [Required(AllowEmptyStrings = false)]
        public string GroupName { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
