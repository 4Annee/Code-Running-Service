namespace CodeService.Models
{
    public class TestingParamValue
    {
        public Guid Id { get; set; }
        public string ParamValue { get; set; }
        public SkeletonParam SkeletonParam{ get; set; }
        public Guid SkeletonParamId { get; set; }
    }
}
