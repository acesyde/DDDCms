using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDDCms.Controllers.Schema.Models.Fields;

namespace DDDCms.Controllers.Schema.Models
{
    public class CreateSchemaDto
    {
        [Required]
        [MinLength(1)]
        public List<FieldDto> Fields { get; set; }
    }
}