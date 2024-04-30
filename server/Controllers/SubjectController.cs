using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Controllers
{
    public class SubjectController : BaseApiController
    {
        private  ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllSubjectsWithSchedule()
        {
            var subjects = await subjectService.GetllAllSubjectsWithScheduleAsync();

            if(subjects == null || subjects.Count() == 0 )
            {
                return NoContent();
            }
            return Ok(subjects);    
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllOpenedSubjects()
        {
            var subjects = await subjectService.GetllAllOpenedSubjectsAsync();
            if (subjects == null || subjects.Count() == 0 )
            {
                return NoContent();
            }
            return Ok(subjects);
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllSubjects()
        {
            var subjects =  await subjectService.GetAllSubjectsAsync();
            if(subjects == null || subjects.Count() == 0)
            {
                return NoContent();
            }
            return Ok(subjects);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewSubject([FromBody] NewSubjectInfo subjectDTO)
        {
            var subject = await subjectService.AddNewSubjectAsync(subjectDTO);  
            if(subject == null)
            {
                return BadRequest();
            }
           
            return Ok(new
            {
                StatusCode = 200,
                StatusMessage = "Add new Subject sucessfully",
                Subject = subjectDTO
            }); 
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteSubject([FromQuery]string subjectId)
        {
            var deletedSubject = await subjectService.DeleteSubjectAsync(subjectId);
            if(deletedSubject != null)
            {
                return Ok(new
                {
                    StatusMessage = "Delete Subject Successfully",
                    deletedSubject
                });
            }

            return BadRequest();
        }
    }
}
