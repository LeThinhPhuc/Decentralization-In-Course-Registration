using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;

namespace BMCSDL.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Account,AccountDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleAccount,RoleAccountDTO>();
            CreateMap<Faculty,FacultyDTO>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<TeacherSubject, TeacherSubjectDTO>(); 
            CreateMap<Teacher, TeacherDTO>().ForMember(dest => dest.TeacherName,
                opt => opt.MapFrom(src => src.Person.FullName));   

        }
    }
}
