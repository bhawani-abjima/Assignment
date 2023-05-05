using AutoMapper;

namespace StudentDataRecord.API.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<Entities.Student, Models.StudentWithoutPointOfInterestDto>();        
        }
    }
}
