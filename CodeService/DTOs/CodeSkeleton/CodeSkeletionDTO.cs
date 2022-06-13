using System.ComponentModel.DataAnnotations;

namespace CodeService.DTOs.CodeSkeleton
{
    public class CodeSkeletonDTO
    {
        [Required]
        public Guid CodeQuestionId { get; set; }
        [Required]
        public Guid ProgrammingLanguageId { get; set; }
        public string Code { get; set; }
    }
}
