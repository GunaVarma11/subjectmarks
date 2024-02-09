using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppStudentDatabase.Data;
using WebAppStudentDatabase.Models;

namespace WebAppStudentDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarksController : ControllerBase
    {
        private readonly SudentDbContext _context;

        public StudentMarksController(SudentDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentMarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentMark>>> GetStudentMark()
        {
          if (_context.StudentMark == null)
          {
              return NotFound();
          }
            return await _context.StudentMark.ToListAsync();
        }

        // GET: api/StudentMarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentMark>> GetStudentMark(int id)
        {
          if (_context.StudentMark == null)
          {
              return NotFound();
          }
            var studentMark = await _context.StudentMark.FindAsync(id);

            if (studentMark == null)
            {
                return NotFound();
            }

            return studentMark;
        }

        // PUT: api/StudentMarks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentMark(int id, StudentMark studentMark)
        {
            if (id != studentMark.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentMark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMarkExists(id))
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

        // POST: api/StudentMarks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentMark>> PostStudentMark(StudentMark studentMark)
        {
          if (_context.StudentMark == null)
          {
              return Problem("Entity set 'SudentDbContext.StudentMark'  is null.");
          }
            _context.StudentMark.Add(studentMark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentMark", new { id = studentMark.StudentId }, studentMark);
        }

        // DELETE: api/StudentMarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentMark(int id)
        {
            if (_context.StudentMark == null)
            {
                return NotFound();
            }
            var studentMark = await _context.StudentMark.FindAsync(id);
            if (studentMark == null)
            {
                return NotFound();
            }

            _context.StudentMark.Remove(studentMark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentMarkExists(int id)
        {
            return (_context.StudentMark?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
