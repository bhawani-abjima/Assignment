using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Dapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StudentMangement.Models;

namespace StudentMangement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IConfiguration _configuration;

        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Db");
            providerName = "System.Data.sqlClient";
        }

        public String ConnectionString { get; }
        public String providerName { get; }

        public IDbConnection Connection
        {
            get{return new SqlConnection(ConnectionString); }
        }   

        public string DeleteStudent(int StudentId)
        {
            throw new NotImplementedException();
        }

        public object GetStudentList()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsList()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (IDbConnection dbConnection=Connection)
                {
                    dbConnection.Open();
                    students=dbConnection.Query<Student>("GetStudentList",commandType:CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return students;    
                }

            }
            catch (Exception ex) 
            {   
                string errormsg = ex.Message;
                return students;
            }
        }

        public string InsertStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public string UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
