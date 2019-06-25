using EventFlow.ValueObjects;

namespace DDDCms.Domain.Schemas.Entities
{
    public class FieldProperties : ValueObject
    {
        public bool IsRequired { get; set; }
        public string Placeholder { get; set; }
        public string Label { get; set; }
        public string Hints { get; set; }
    }
}