using EventFlow.Entities;

namespace DDDCms.Domain.Schemas.Entities
{
    public abstract class FieldEntity : Entity<FieldId>
    {
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsHidden { get; set; }
        public FieldProperties Properties { get; set; }
        
        protected FieldEntity(FieldId id) : base(id)
        {
        }
    }
}