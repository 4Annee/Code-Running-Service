using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeService.Data;
using CodeService.Models;
using AutoMapper;
using CodeService.DTOs.CodeSkeleton;

namespace CodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionSkeletonsController : ControllerBase
    {
        private readonly CodeServiceContext _context;
        private readonly IMapper mapper;

        public QuestionSkeletonsController(CodeServiceContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }


        // GET: api/QuestionSkeletons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<QuestionSkeleton>>> GetQuestionSkeletonByQtID(Guid id)
        {
            if (_context.QuestionSkeletons == null)
            {
                return NotFound();
            }
            var questionSkeleton = await _context.QuestionSkeletons.Where(qt => qt.CodeQuestionId == id).ToListAsync();

            if (questionSkeleton == null)
            {
                return NotFound();
            }

            return Ok(questionSkeleton);
        }

        // PUT: api/QuestionSkeletons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionSkeleton(Guid id, QuestionSkeleton questionSkeleton)
        {
            if (id != questionSkeleton.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionSkeleton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionSkeletonExists(id))
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

        // POST: api/QuestionSkeletons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionSkeleton>> PostQuestionSkeleton(CodeSkeletonCreationDTO questionSkeleton)
        {
            if (_context.QuestionSkeletons == null)
            {
                return Problem("Entity set 'CodeServiceContext.QuestionSkeletons'  is null.");
            }

            var newQuestionSkeleton = mapper.Map<QuestionSkeleton>(questionSkeleton);
            var id = _context.QuestionSkeletons.Add(newQuestionSkeleton).Entity.Id;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionSkeleton", new { id = id }, questionSkeleton);
        }

        // DELETE: api/QuestionSkeletons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionSkeleton(Guid id)
        {
            if (_context.QuestionSkeletons == null)
            {
                return NotFound();
            }
            var questionSkeleton = await _context.QuestionSkeletons.FindAsync(id);
            if (questionSkeleton == null)
            {
                return NotFound();
            }

            _context.QuestionSkeletons.Remove(questionSkeleton);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionSkeletonExists(Guid id)
        {
            return (_context.QuestionSkeletons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
