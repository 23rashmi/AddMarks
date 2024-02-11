using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAddMarks.Data;
using WebApplicationAddMarks.Models;

namespace WebApplicationAddMarks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly AddMarksDbContext _context;

        public MarksController(AddMarksDbContext context)
        {
            _context = context;
        }

        // GET: api/Marks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marks>>> GetMark()
        {
          if (_context.Mark == null)
          {
              return NotFound();
          }
            return await _context.Mark.ToListAsync();
        }

        // GET: api/Marks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marks>> GetMark(int id)
        {
          if (_context.Mark == null)
          {
              return NotFound();
          }
            var mark = await _context.Mark.FindAsync(id);

            if (mark == null)
            {
                return NotFound();
            }

            return mark;
        }

        // PUT: api/Marks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMark(int id, Marks mark)
        {
            if (id != mark.MarkId)
            {
                return BadRequest();
            }

            _context.Entry(mark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkExists(id))
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

        // POST: api/Marks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Marks>> PostMark(Marks mark)
        {
          if (_context.Mark == null)
          {
              return Problem("Entity set 'AddMarksDbContext.Mark'  is null.");
          }
            _context.Mark.Add(mark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMark", new { id = mark.MarkId }, mark);
        }

        // DELETE: api/Marks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMark(int id)
        {
            if (_context.Mark == null)
            {
                return NotFound();
            }
            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }

            _context.Mark.Remove(mark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarkExists(int id)
        {
            return (_context.Mark?.Any(e => e.MarkId == id)).GetValueOrDefault();
        }
    }
}
