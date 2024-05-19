using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Net.WebSockets;

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



        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllTeachersWithSchedule()
        {
            var teachersWithSchedule = await teacherService.GetAllTeachersWithSubjects();

            if (teachersWithSchedule == null)
            {
                return NoContent();
            }
            return Ok(teachersWithSchedule);

        }


        [Authorize(Roles ="truongphokhoa,truongbomon,giaovu,giaovien")]
        [HttpGet("[action]")]
        public async Task<ActionResult> TeacherTeachingSchedule([FromQuery] string teacherId)
        {
            var teacherSchedule = await teacherService.GetTeacherTeachingSchelduleAsync(teacherId);
            if(teacherSchedule  == null)
            {
                return NoContent();
            }
            return Ok(teacherSchedule);
        }


        [Authorize(Roles = "truongphokhoa,truongbomon,giaovu,giaovien")]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetTeacherById([FromQuery]string teacherId)
        {
            var teacher =  await teacherService.GetTeacherByIdAsync(teacherId);    

            if(teacher == null)
            {
                return BadRequest();
            }

            return Ok(teacher); 
        }

        

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteTeacherTime([FromBody] NewScheduleDTO teacherTimeDTO)
        {
            var deletedTime = await teacherService.RemoveTeacherTimeAsync(teacherTimeDTO);

            if(deletedTime == null)
            {
                return NoContent();
            }
            return Ok(new
            {
                Status = "Remove Time Successfully",
                DeletedTime = deletedTime
            });
        }

       
    }
}
