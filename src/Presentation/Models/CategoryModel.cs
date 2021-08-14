using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }
    }
}