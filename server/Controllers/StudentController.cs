using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BMCSDL.Controllers
{
    public class StudentController : BaseApiController
    {
        private IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllStudents()
        {
            var students = await this.studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetStudentByStudentId([FromQuery] string studentId)
        {
            var student = await this.studentService.GetStudentByIdAsync(studentId);

            if(student == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể không tìm thấy student Id"
                });
            }

            return Ok(student);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateSudentInformation([FromBody] UpdateStudentInfo studentInfo)
        {
            var isExistedStudent = await studentService.UpdateStudentByAsync(studentInfo);
            if(isExistedStudent == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể StudentId hoặc faculty không hợp lệ"
                }); ;
            }
            return Ok(new { 
                StatusMessage = "Update Successfully",
                Info = studentInfo
            });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetRegisteredSubjectsByStudentId([FromQuery] string studentId)
        {
            var registeredSubjects = await studentService.GetRegisteredSubjectsAsync(studentId);
            return Ok(registeredSubjects);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> RegisterSubject([FromBody] RegistrationSubjectFormDTO regisForm)
        {
            var newRegistration = await studentService.RegisterSubjectAsync(regisForm);
            if (newRegistration == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể môn đã đăng ký hoặc hết slot hoặc môn học không được mở"
                });
            }
            

            return Ok(new
            {
                StatusCode = "200",
                Status = "Register Successfully",
                Subject = newRegistration
            });

        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleleRegisteredSubject([FromBody] RegistrationSubjectFormDTO regisForm)
        {
            var deletingSubject = await studentService.RemoveRegisteredSubjectAsync(regisForm);
            if (deletingSubject == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Status = "Delete Successfully",
                Subject = deletingSubject
            });
        }


    }
}
