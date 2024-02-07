
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Frontend.Models
{
    public class Group
    {

        [Key]
        public int GroupId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string GroupName { get; set; }
        public int CategoryId { get; set; }
    
        public List<Product>? Products { get; set; }

        
        public Category? Category { get; set; }

    }
}
