using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IStudentService
    {
        Task<object> RegisterSubjectAsync(RegistrationSubjectFormDTO regisForm);
        Task<object> RemoveRegisteredSubjectAsync(RegistrationSubjectFormDTO regisForm);

        Task<object> GetRegisteredSubjectsAsync(string studentId);


        Task<IEnumerable<StudentDTO>> GetAllStudents(); 

        Task<object> GetStudentByIdAsync(string studentId);

        Task<object> UpdateStudentByAsync(UpdateStudentInfo studentInfo);
    }
}
