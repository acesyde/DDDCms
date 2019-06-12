using EventFlow.Core;

namespace DDDCms.Domain.Document.Entities
{
    public class FieldId : Identity<FieldId>
    {
        public FieldId(string value) : base(value)
        {
        }
    }
}