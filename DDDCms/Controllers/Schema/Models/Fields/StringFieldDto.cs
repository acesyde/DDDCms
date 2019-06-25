namespace DDDCms.Controllers.Schema.Models.Fields
{
    public sealed class StringFieldDto : FieldDto
    {
        public string DefaultValue { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
    }
}