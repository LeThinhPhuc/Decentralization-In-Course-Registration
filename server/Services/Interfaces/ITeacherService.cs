using BMCSDL.DTOs;
using BMCSDL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherAndTimeDTO>> GetAllTeachersAsync();

        Task<SubjectClassDTO> AddTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO);
        Task<SubjectClassDTO> RemoveTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO);
    }
}
