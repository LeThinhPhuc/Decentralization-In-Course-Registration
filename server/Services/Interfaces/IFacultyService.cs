using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<IEnumerable<object>> GetAllFacultiesAsync();
        Task<IEnumerable<object>> GetAllFacultiesWithSubjectsAsync();

        Task<object> GetFacultyByIdAsync(string facultyId);
        Task<object> GetFacultyWithSubjectsByIdAsync(string facultyId);

        Task<object> AddNewFacultyAsync(FacultyDTO newFaculty);

        Task<object> RemoveFacultyAsync(string facultyId);

        Task<object> UpdateFacultyAsync(FacultyDTO newInfo);

    }
}
