using StudentDataBase.Models;

namespace StudentDataBase.Infra
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAll();

        Task<Student> GetById(int id);
    }
}
