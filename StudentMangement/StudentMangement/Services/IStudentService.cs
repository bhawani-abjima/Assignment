using StudentMangement.Models;

namespace StudentMangement.Services
{
    public interface IStudentService
    {
        public List<Student> GetStudentsList();
        public String InsertStudent(Student student);
        public String UpdateStudent(Student student);

        public string DeleteStudent(int StudentId);
        object GetStudentList();
    }
}
