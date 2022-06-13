namespace CodeService.Models
{
    public class CodeQuestion
    {
        public Guid Id { get; set; }
        public List<QuestionSkeleton> Skeletons { get; set; }
    }
}
