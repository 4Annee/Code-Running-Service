namespace CodeService.Models
{
    public class CodeQuestion
    {
        public Guid Id { get; set; }
        public List<TestingParams> TestingParams { get; set; }
    }
}
