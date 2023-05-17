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

        public List<StudentDetails> GetAll()
        {
            return _context.StudentDetails.ToList();
        }

        public StudentDetails GetById(int id)
        {
            return _context.StudentDetails.FirstOrDefault(X=>X.Id == id);
        }
    }
}
