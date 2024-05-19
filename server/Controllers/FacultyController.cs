using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Controllers
{
    public class FacultyController : BaseApiController
    {
        private IFacultyService facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            this.facultyService = facultyService;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllFaculties()
        {
            var faculties = await facultyService.GetAllFacultiesAsync();
            if (faculties == null)
            {
                return NoContent();
            }
            return Ok(faculties);
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllStudentsByFacultyId(string facultyId)
        {
            var students = await facultyService.GetAllStudentsByFacultyId(facultyId);
            if(students == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể facultyId không đúng hoặc không có sinh viên thuộc khoa này"
                });
            }

            return Ok(students);
        }

        [Authorize(Roles = "truongkhoa,giaovu,truongbomon")]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllTeachersByFacultyId(string facultyId)
        {
            var teachers = await facultyService.GetAllTeachersByFacultyId(facultyId);
            if (teachers == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể facultyId không đúng hoặc không có giáo viên thuộc khoa này"
                });
            }

            return Ok(teachers);

        }

        [Authorize(Roles = "truongkhoa")]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllAccountsByFacultyId([FromQuery]string facultyId)
        {
            var accounts = await facultyService.GetAllAccountsByFacultyIdAsync(facultyId);
            
            if(accounts == null)
            {
                return BadRequest(new
                {
                    Message = "Có thẻ facultyId bị sai hoặc không có student thuộc khoa này"
                });
            }
            return Ok(accounts);
        }



        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllFacultiesWithSubject()
        {
            var faculties = await facultyService.GetAllFacultiesWithSubjectsAsync();
            if (faculties == null)
            {
                return NoContent();
            }
            return Ok(faculties);
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetFacultyById([FromQuery] string facultyId)
        {
            var faculty = await facultyService.GetFacultyByIdAsync(facultyId);
            if (faculty == null) {
                return BadRequest(new
                {
                    Message = "Có thể sai facultyId"
                });
            }
            return Ok(faculty);
        }



        [HttpGet("[action]")]
        public async Task<ActionResult> GetFacultyWithSubjects(string facultyId)
        {
            var faculty = await facultyService.GetFacultyWithSubjectsByIdAsync(facultyId);
            if (faculty == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể sai facultyId"
                });
            }
            return Ok(faculty);
        }


        [Authorize(Roles = "truongphokhoa,truongbomon")]
        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewFaculty([FromBody]FacultyDTO newFaculty)
        {
            var dataToReturn = await facultyService.AddNewFacultyAsync(newFaculty);
            
            return Ok(new
            {
                StatusCode = 200,
                StatusMessage = "Add Successfully",
                Response = dataToReturn 
            });    
        }


        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteFaculty([FromQuery] string facultyId)
        {
            var dataToReturn = await facultyService.RemoveFacultyAsync(facultyId);

            if (dataToReturn == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Có thể facultyId không đúng"
                });
            }

            return Ok(new
            {
                StatusCode = 200,
                StatusMessage = "Delete Successfully",
                Response = dataToReturn
            });
        }



        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateFaculty([FromBody] FacultyDTO updateFaculty)
        {
            var response = await facultyService.UpdateFacultyAsync(updateFaculty);

            if(response == null)
            {
                return null;
            }

            return Ok(new
            {
                StatusCode = 200,
                StatusMessage = "Update sucessfully",
                Response = response
            });
        }


    }
}
