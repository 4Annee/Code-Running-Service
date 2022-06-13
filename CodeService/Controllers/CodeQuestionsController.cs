using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeService.Data;
using CodeService.Models;

namespace CodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeQuestionsController : ControllerBase
    {
        private readonly CodeServiceContext _context;

        public CodeQuestionsController(CodeServiceContext context)
        {
            _context = context;
        }

        // GET: api/CodeQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeQuestion>>> GetCodeQuestions()
        {
          if (_context.CodeQuestions == null)
          {
              return NotFound();
          }
            return await _context.CodeQuestions.ToListAsync();
        }

        // GET: api/CodeQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeQuestion>> GetCodeQuestion(Guid id)
        {
          if (_context.CodeQuestions == null)
          {
              return NotFound();
          }
            var codeQuestion = await _context.CodeQuestions.FindAsync(id);

            if (codeQuestion == null)
            {
                return NotFound();
            }

            return codeQuestion;
        }

        // PUT: api/CodeQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeQuestion(Guid id, CodeQuestion codeQuestion)
        {
            if (id != codeQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(codeQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeQuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CodeQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CodeQuestion>> PostCodeQuestion(CodeQuestion codeQuestion)
        {
          if (_context.CodeQuestions == null)
          {
              return Problem("Entity set 'CodeServiceContext.CodeQuestions'  is null.");
          }
            _context.CodeQuestions.Add(codeQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeQuestion", new { id = codeQuestion.Id }, codeQuestion);
        }

        // DELETE: api/CodeQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeQuestion(Guid id)
        {
            if (_context.CodeQuestions == null)
            {
                return NotFound();
            }
            var codeQuestion = await _context.CodeQuestions.FindAsync(id);
            if (codeQuestion == null)
            {
                return NotFound();
            }

            _context.CodeQuestions.Remove(codeQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CodeQuestionExists(Guid id)
        {
            return (_context.CodeQuestions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
