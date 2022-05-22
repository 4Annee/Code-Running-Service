﻿using CodeService.Models;

namespace CodeService.Services
{
    public interface IFileManagementService
    {
        string CreateFileForCode(string code, string ext);
        string ReplaceParamsInFile(string code, TestingParamValue[] paramValues);
        bool DeleteCodeFile(string filename);

    }
    public class FileManagementService : IFileManagementService
    {
        public string CreateFileForCode(string code, string ext)
        {
            var filename = "code" + Guid.NewGuid() + ext;
            var filen = Path.Combine("CodeFiles", filename);
            File.WriteAllText(filen, code);
            return filen;
        }

        public bool DeleteCodeFile(string filename)
        {
            File.Delete(filename);
            return true;
        }

        public string ReplaceParamsInFile(string code, TestingParamValue[] paramValues)
        {
            throw new NotImplementedException();
        }
    }
}
