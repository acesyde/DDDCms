using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DDDCms.Domain.Document.Entities;

namespace DDDCms.Controllers.Document.Models.Fields
{
    public abstract class FieldDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Name { get; set; }
    }

    public static class FieldDtoExtensions
    {
        public static IEnumerable<FieldEntity> ToEntities(this IEnumerable<FieldDto> fieldDtos)
        {
            var enumerable = fieldDtos as FieldDto[] ?? fieldDtos.ToArray();
            if (!enumerable.Any())
                yield break;

            foreach (var dto in enumerable)
            {
                var entity = dto.ToEntity();
                if (entity != null)
                    yield return entity;
            }
        }

        private static FieldEntity ToEntity(this FieldDto fieldDto)
        {
            switch (fieldDto)
            {
                case StringFieldDto stringfieldtype:
                    return new StringFieldEntity(FieldId.New, stringfieldtype.Name)
                    {
                        DefaultValue = stringfieldtype.DefaultValue,
                        MaxLenght = stringfieldtype.MaxLength,
                        MinLenght = stringfieldtype.MinLength
                    };
            }

            return null;
        }
    }
}