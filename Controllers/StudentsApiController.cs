using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab4_RazorApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_RazorApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.OrderBy(s => s.FullName).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentId) return BadRequest();

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}