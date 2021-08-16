using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be greater than 3 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string Type {get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string Tags { get; set; }

        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}