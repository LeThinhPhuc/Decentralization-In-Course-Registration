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

            if (student == null)
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
            if (isExistedStudent == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể StudentId hoặc faculty không hợp lệ"
                }); ;
            }
            return Ok(new
            {
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
                    Message = "Có thể môn đã đăng ký hoặc hết slot hoặc môn học không được mở hoặc không có trong thời khóa biểu"
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
                return BadRequest(new
                {
                    Message = "Có thể sinh viên chưa đăng kí môn học hoặc id sai"
                });
            }
            return Ok(new
            {
                Status = "Delete Successfully",
                Subject = deletingSubject
            });
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateMark([FromBody] UpdateMarkForm newMark)
        {
            var response = await studentService.UpdateMarkAsync(newMark);


            if (int.TryParse(response.ToString(), out int result1) && result1 == 1)
            {
                return BadRequest(new
                {
                    Message = "Có thể studentId bị sai"
                });
            }

            if (int.TryParse(response.ToString(), out int result2) && result2 == 2)
            {
                return BadRequest(new
                {
                    Message = "có thể subjectId bị sai"
                });
            }

            if (int.TryParse(response.ToString(), out int result3) && result3 == 3)
            {
                return BadRequest(new
                {
                    Message = "có thể student không học môn đó"
                });
            }


            return Ok(new
            {
                Message = "Update Successfully",
                response = response
            });
        }


    }
}
