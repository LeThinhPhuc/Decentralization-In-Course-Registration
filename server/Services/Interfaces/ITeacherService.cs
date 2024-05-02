using BMCSDL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<object>> GetAllTeachersAsync();

        Task<IEnumerable<object>> GetAllTeachersWithSubjects();

        Task<object> GetTeacherTeachingSchelduleAsync(string teacherId);

        Task<object> GetTeacherByIdAsync(string teacherId);

        Task<object> RemoveTeacherTimeAsync(NewScheduleDTO teacherTimeDTO);
    }
}
