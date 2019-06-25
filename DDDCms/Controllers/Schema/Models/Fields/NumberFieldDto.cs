namespace DDDCms.Controllers.Schema.Models.Fields
{
    public class NumberFieldDto : FieldDto
    {
        public double DefaultValue { get; set; }
        public double? MaxValue { get; set; }
        public double? MinValue { get; set; }
    }
}