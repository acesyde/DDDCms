using EventFlow.Core;

namespace DDDCms.Domain.Schemas.Entities
{
    public class FieldId : Identity<FieldId>
    {
        public FieldId(string value) : base(value)
        {
        }
    }
}