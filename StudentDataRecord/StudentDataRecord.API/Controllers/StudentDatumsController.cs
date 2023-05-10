using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDataRecord.API.Models;

namespace StudentDataRecord.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDatumsController : ControllerBase
    {
        private readonly StudentDetailsContext _context;

        public StudentDatumsController(StudentDetailsContext context)
        {
            _context = context;
        }

        // GET: api/StudentDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDatum>>> GetStudentData()
        {
          if (_context.StudentData == null)
          {
              return NotFound();
          }
            return await _context.StudentData.ToListAsync();
        }

        // GET: api/StudentDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDatum>> GetStudentDatum(int id)
        {
          if (_context.StudentData == null)
          {
              return NotFound();
          }
            var studentDatum = await _context.StudentData.FindAsync(id);

            if (studentDatum == null)
            {
                return NotFound();
            }

            return studentDatum;
        }

        // PUT: api/StudentDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDatum(int id, StudentDatum studentDatum)
        {
            if (id != studentDatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDatumExists(id))
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

        // POST: api/StudentDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDatum>> PostStudentDatum(StudentDatum studentDatum)
        {
          if (_context.StudentData == null)
          {
              return Problem("Entity set 'StudentDetailsContext.StudentData'  is null.");
          }
            _context.StudentData.Add(studentDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDatum", new { id = studentDatum.Id }, studentDatum);
        }

        // DELETE: api/StudentDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentDatum(int id)
        {
            if (_context.StudentData == null)
            {
                return NotFound();
            }
            var studentDatum = await _context.StudentData.FindAsync(id);
            if (studentDatum == null)
            {
                return NotFound();
            }

            _context.StudentData.Remove(studentDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentDatumExists(int id)
        {
            return (_context.StudentData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
