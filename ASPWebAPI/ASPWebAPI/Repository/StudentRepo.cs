using ASPWebAPI.Infrastructure;
using ASPWebAPI.Models;

namespace ASPWebAPI.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentsDataContext _context;

        public StudentRepo(StudentsDataContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetByID(int id)
        {
            var student =  _context.Students.FirstOrDefault(x => x.Id == id);
            return student;
        }
    }
}
