using AutoMapper;
using StudentsDetails.Entities;
using StudentsDetails.Models;

namespace StudentsDetails.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<StudentDetails,StudentDetails>();
            CreateMap<StudentDetails,StudentDetails>();
        }
    }
}
    