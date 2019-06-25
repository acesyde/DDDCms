using EventFlow.Entities;

namespace DDDCms.Domain.Schemas.Entities
{
    public abstract class FieldEntity : Entity<FieldId>
    {
        protected FieldEntity(FieldId id) : base(id)
        {
        }
    }
}