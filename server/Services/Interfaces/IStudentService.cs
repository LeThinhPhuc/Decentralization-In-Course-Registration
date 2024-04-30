using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IStudentService
    {
        Task<SubjectDTO> RegisterSubjectAsync(RegistrationSubjectFormDTO regisForm);
        Task<SubjectDTO> RemoveRegisteredSubjectAsync(RegistrationSubjectFormDTO regisForm);

        Task<object> GetRegisteredSubjectsAsync(string studentId);

        Task<IEnumerable<StudentDTO>> GetAllStudents(); 

        Task<object> GetStudentByIdAsync(string studentId); 
    }
}
