namespace CodeService.Models
{
    public class SkeletonParam
    {
        public Guid Id { get; set; }
        public string ParamName { get; set; }
        public ParamType ParamType{ get; set; }
        public string? DefaultValue { get; set; } = null;
    }
}
