using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDDCms.Controllers.Document.Models.Fields;

namespace DDDCms.Controllers.Document.Models
{
    public class CreateDocumentDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public List<FieldDto> Fields { get; set; }
    }
}