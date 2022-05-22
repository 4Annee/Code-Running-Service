using CodeService.Data;
using CodeService.Models;

namespace CodeService.Services
{
    public interface IProgrammingLanguagesService {
        ProgrammingLanguage GetProgrammingLanguageByName(string ProgrammingLang);
        String GetSkeletonByProgrammingLanguage(Guid codeid);
    }
    public class ProgrammingLanguagesService : IProgrammingLanguagesService
    {
        private readonly CodeServiceContext serviceContext;

        public ProgrammingLanguagesService(CodeServiceContext serviceContext)
        {
            this.serviceContext = serviceContext;
        }
        public ProgrammingLanguage GetProgrammingLanguageByName(string ProgrammingLang)
        {
            return serviceContext.ProgrammingLanguages.FirstOrDefault(pl => pl.Name.ToLower() == ProgrammingLang.ToLower());
        }

        public string GetSkeletonByProgrammingLanguage(Guid codeid)
        {
            
            return null;
        }
    }
}
