using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class TypeModel
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(36, ErrorMessage = "Category value must be valid.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500)]
        public string Description { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}