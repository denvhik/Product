using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; } 
        
        public int? GroupId { get; set; }
        [Required]
         public Group Group { get; set; }
    }
}
