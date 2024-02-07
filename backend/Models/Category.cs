using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Category
    {
        
        public int? CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public List<Group> Groups { get; set; }
    }
}
