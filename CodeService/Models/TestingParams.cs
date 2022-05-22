namespace CodeService.Models
{
    public class TestingParams
    {
        public Guid Id { get; set; }
        public bool hidden { get; set; }
        public List<TestingParamValue> TestingParamValues{ get; set; }
    }
}
