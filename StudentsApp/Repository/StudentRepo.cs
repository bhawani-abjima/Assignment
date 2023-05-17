using Microsoft.EntityFrameworkCore;
using StudentsApp.Infrastructure;
using StudentsApp.Models;

namespace StudentsApp.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentsDataContext _context;

        public StudentRepo(StudentsDataContext context)
        {
            _context = context;
            
        }
        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByID(int? id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return student;
        }
    }
}
