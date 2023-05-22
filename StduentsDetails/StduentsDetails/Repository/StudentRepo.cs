using Microsoft.EntityFrameworkCore;
using StudentsDetails.Infrastructure;
using StudentsDetails.Models;

namespace StudentsDetails.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentDetailsContext _context;

        public StudentRepo(StudentDetailsContext context)
        {
            _context = context;
        }

        public async Task<List<StudentDatum>> GetAll()
        {
            return await _context.StudentData.ToListAsync();
        }

        public StudentDatum GetById(int id)
        {
            return _context.StudentData.FirstOrDefault(X=>X.Id == id);
        }

    }
}
