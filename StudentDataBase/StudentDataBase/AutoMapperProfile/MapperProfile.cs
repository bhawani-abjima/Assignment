using AutoMapper;
using StudentDataBase.Entities;
using StudentDataBase.Models;

namespace StudentDataBase.AutoMapperProfile
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentDetails>();
            CreateMap<StudentDetails, Student>();

        }
    }
}
