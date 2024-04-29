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
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetAllSubjects()
        {
            var subjects = await subjectService.GetllAllSubjectsAsync();

            if(subjects.Count() == 0 || subjects == null)
            {
                return BadRequest();
            }
            return Ok(subjects);    
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewSubject([FromBody] SubjectDTO subjectDTO)
        {
            var subject = await subjectService.AddNewSubjectAsync(subjectDTO);  

            return Ok(subject); 
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteSubject([FromQuery]string subjectId)
        {
            var deletedSubject = await subjectService.DeleteSubjectAsync(subjectId);
            if(deletedSubject != null)
            {
                return Ok(deletedSubject);
            }

            return BadRequest();
        }
    }
}
