using BMCSDL.DTOs;
using BMCSDL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<object>> GetAllTeachersAsync();

        Task<object> GetTeacherTeachingSchelduleAsync(string teacherId);

        Task<object> GetTeacherByIdAsync(string teacherId);

        Task<object> AddTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO);
        Task<object> RemoveTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO);
    }
}
