using CodeService.DTOs.CodeAnswer;

namespace CodeService.Services
{
    public interface ICodeRunningService
    {
        Task<string> RunCode(CodeAnswerDto codeAnswer);
    }
}