using System.ComponentModel.DataAnnotations;

namespace backend.Models.ViewModel
{
    public class GroupDto
    {

        public int? GroupId { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string GroupName { get; set; }
        [Required]
        public int CategoryId { get; set; }
       
    }
}
