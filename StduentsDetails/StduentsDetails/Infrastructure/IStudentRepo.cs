
using StudentsDetails.Models;

namespace StudentsDetails.Infrastructure
{
    public interface IStudentRepo
    {
        Task<List<StudentDatum>> GetAll();
        
        StudentDatum GetById(int id);
    }
}
