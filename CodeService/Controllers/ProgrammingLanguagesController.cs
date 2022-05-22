#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeService.Models;
using CodeService.Data;

namespace CodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly CodeServiceContext _context;

        public ProgrammingLanguagesController(CodeServiceContext context)
        {
            _context = context;
        }

        // GET: api/ProgrammingLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgrammingLanguage>>> GetProgrammingLanguage()
        {
            return await _context.ProgrammingLanguages.ToListAsync();
        }

        // GET: api/ProgrammingLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammingLanguage>> GetProgrammingLanguage(Guid id)
        {
            var programmingLanguage = await _context.ProgrammingLanguages.FindAsync(id);

            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return programmingLanguage;
        }

        // PUT: api/ProgrammingLanguages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgrammingLanguage(Guid id, ProgrammingLanguage programmingLanguage)
        {
            if (id != programmingLanguage.Id)
            {
                return BadRequest();
            }

            _context.Entry(programmingLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammingLanguageExists(id))
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

        // POST: api/ProgrammingLanguages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgrammingLanguage>> PostProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            _context.ProgrammingLanguages.Add(programmingLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgrammingLanguage", new { id = programmingLanguage.Id }, programmingLanguage);
        }

        // DELETE: api/ProgrammingLanguages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgrammingLanguage(Guid id)
        {
            var programmingLanguage = await _context.ProgrammingLanguages.FindAsync(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            _context.ProgrammingLanguages.Remove(programmingLanguage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgrammingLanguageExists(Guid id)
        {
            return _context.ProgrammingLanguages.Any(e => e.Id == id);
        }
    }
}
