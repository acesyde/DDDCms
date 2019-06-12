using EventFlow.Entities;

namespace DDDCms.Domain.Document.Entities
{
    public abstract class FieldEntity : Entity<FieldId>
    {
        public string Name { get; set; }
        
        protected FieldEntity(FieldId id, string name) : base(id)
        {
            Name = name;
        }
    }
}