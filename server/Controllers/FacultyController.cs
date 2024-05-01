using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
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
