using EventFlow.Core;

namespace DDDCms.Domain.Schemas
{
    public class SchemaId : Identity<SchemaId>
    {
        public SchemaId(string value) : base(value)
        {
        }
    }
}