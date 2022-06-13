using CodeService.Data;
using CodeService.DTOs.CodeAnswer;
using CodeService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeRunningController : ControllerBase
    {
        private readonly CodeServiceContext context;
        private readonly ICodeRunningService service;
        private readonly IProgrammingLanguagesService plservice;

        public CodeRunningController( CodeServiceContext context, ICodeRunningService service,IProgrammingLanguagesService plservice)
        {
            this.context = context;
            this.service = service;
            this.plservice = plservice;
        }

        [HttpPost]
        public async Task<IActionResult> TryToRunCode(CodeAnswerDto answerDto)
        {
            try
            {
                return Ok(await service.RunCode(answerDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
