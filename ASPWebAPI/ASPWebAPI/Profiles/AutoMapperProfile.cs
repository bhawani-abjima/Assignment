using ASPWebAPI.DTO;
using ASPWebAPI.Models;
using AutoMapper;

namespace ASPWebAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDTO>();
        }
    }
}
