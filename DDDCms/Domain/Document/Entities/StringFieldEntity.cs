namespace DDDCms.Domain.Document.Entities
{
    public class StringFieldEntity : FieldEntity
    {
        public string DefaultValue { get; set; }
        public int? MaxLenght { get; set; }
        public int? MinLenght { get; set; }
        
        public StringFieldEntity(FieldId id, string name) : base(id, name)
        {
        }
    }
}