using StudentsApp.Models;

namespace StudentsApp.Infrastructure
{
    public interface IStudentRepo
    {
        Task<List<Student>>GetAll();
        Task<Student> GetByID(int? id);
    }
}
