using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class SizeModel
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "The maximum of charecters allowed is 500.")]
        public string Description { get; set; }
    }
}