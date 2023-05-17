
using StudentsDetails.Models;

namespace StudentsDetails.Infrastructure
{
    public interface IStudentRepo
    {
        List<StudentDetails> GetAll();
        
        StudentDetails GetById(int id);
    }
}
