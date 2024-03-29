using ProductManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public Cate? Category { get; set; }
        public IFormFile Photo { get; set; }

    }
}
