using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace BMCSDL.Controllers
{
    public class TeacherController : BaseApiController
    {
        private  ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllTeachers()
        {
            var teachers = await teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddTeacherTime([FromBody] TeacherNewTimeDTO teacherTimeDTO)
        {
            var newTime = await teacherService.AddTeacherTimeAsync(teacherTimeDTO);

            if(newTime == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Status = "Add new time successfully",
                NewTime = newTime
            });

        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteTeacherTime([FromBody] TeacherNewTimeDTO teacherTimeDTO)
        {
            var deletedTime = await teacherService.RemoveTeacherTimeAsync(teacherTimeDTO);

            if(deletedTime == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Status = "Remove Time Successfully",
                DeletedTime = deletedTime
            });
        }

    }
}
