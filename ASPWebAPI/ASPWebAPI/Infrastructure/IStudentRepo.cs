using ASPWebAPI.Models;

namespace ASPWebAPI.Infrastructure
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetByID(int id);
    }
}
