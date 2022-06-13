using CodeService.DTOs.CodeAnswer;
using System.Diagnostics;

namespace CodeService.Services
{
    public class CodeRunningService : ICodeRunningService
    {
        private readonly IProgrammingLanguagesService plservice;
        private readonly IFileManagementService filMng;

        public CodeRunningService(IProgrammingLanguagesService plservice,
            IFileManagementService fileMng)
        {
            this.plservice = plservice;
            this.filMng = fileMng;
        }

        public Task<string> RunCode(CodeAnswerDto codeAnswer)
        {
            // Get The Programming Language Of Choice
            var pl = plservice.GetProgrammingLanguageByName(codeAnswer.ProgrammingLanguage);
            // Create The File Containing The Code
            var filename = filMng.CreateFileForCode(codeAnswer.Code, pl.FileExtension);
            // Create A Process
            var psi = new ProcessStartInfo(pl.Command, filename) { RedirectStandardOutput = true ,RedirectStandardError=true};
            // Start The Process Of Code Running
            var proc = Process.Start(psi);
            string Output = "";
            if (proc == null)
            {
                Console.WriteLine("Can not exec.");
            }
            else
            {
                
                Console.WriteLine("-------------Start read standard output--------------");
                //Start reading
                using (var sr = proc.StandardOutput)
                {
                    using var er = proc.StandardError;
                    Output = sr.ReadToEnd();
                    Output += er.ReadToEnd();
                    if (!proc.HasExited)
                    {
                        proc.Kill();
                    }
                }
                Console.WriteLine("---------------Read end------------------");
                Console.WriteLine($"Exited Code ： {proc.ExitCode}");
            }
            // TODO : Delete The Created File
            filMng.DeleteCodeFile(filename);
            return Task.FromResult(Output);
        }

    }
}
