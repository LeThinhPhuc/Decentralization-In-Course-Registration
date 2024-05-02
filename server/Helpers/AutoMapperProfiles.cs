using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;

namespace BMCSDL.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Faculty,FacultyDTO>();
            CreateMap<Teacher, TeacherDTO>().ForMember(dest => dest.Faculty,
                opt => opt.MapFrom(src => src.Person.Faculty));
            CreateMap<Account,AccountDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleAccount,RoleAccountDTO>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<TeacherSubject, TeacherSubjectDTO>();
            CreateMap<StudentRegisteredSubject, StudentRegisteredSubjectDTO>();
            CreateMap<Student, StudentDTO>().ForMember(dest => dest.Faculty,
                opt => opt.MapFrom(src => src.Person.Faculty));   
            CreateMap<Person,PersonDTO>();  
            CreateMap<Teacher,TeacherDTO>();    
            CreateMap<Time,TimeDTO>();
            CreateMap<SubjectClass, SubjectClassDTO>();
            CreateMap<Classroom, ClassroomDTO>();   
        }
    }
}
