namespace CodeService.Models
{
    public class QuestionSkeleton
    {
        // Skeleton ID
        public Guid Id { get; set; }
        // Foreign Keys To Other Entities
        public CodeQuestion Question { get; set; }
        public Guid CodeQuestionId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public Guid ProgrammingLanguageId { get; set; }


        public string Code { get; set; }
    }
}
