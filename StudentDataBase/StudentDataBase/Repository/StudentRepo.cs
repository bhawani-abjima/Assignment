using Microsoft.EntityFrameworkCore;
using StudentDataBase.Data;
using StudentDataBase.Infra;
using StudentDataBase.Models;


namespace StudentDataBase.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentDataBaseContext _context;

        public StudentRepo(StudentDataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Student.ToListAsync();
        }

        //public async Task<Student> GetById(int id)
        //{
        //    var student =await _context.Student.FirstOrDefaultAsync(X => X.Id == id);
        //    return student;

        //}

        public async Task<Student> GetById(int id)
        {
            var newStudent = await _context.Student.FirstOrDefaultAsync(X => X.Id == id);
            return newStudent;
        }
    }
}
