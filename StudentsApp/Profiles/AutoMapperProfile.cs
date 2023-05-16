using AutoMapper;
using StudentsApp.Models;

namespace StudentsApp.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
