

using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public Cate? Category { get; set; }

        public string PhotoPath { get; set; }  
    
        
        //public int CategoryId { get; set; }


    }
}
