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

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateSubject([FromBody] UpdateSubjectInfo subjectDTO)
        {
            var dataToReturn = await subjectService.UpdateSubjectAsync(subjectDTO);   

            if(dataToReturn == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể mã môn học không đúng hoặc mã khoa không đúng"
                });
            }

            return Ok(new
            {
                StatusCode =200,
                StatusMessage = "Update successfully",
                Subject = subjectDTO    
            });
        }


        [HttpPut("[action]")]
        public async Task<ActionResult> OpenOrCloseSubject([FromBody] OpenCloseSubject isOpen)
        {
            var response = await subjectService.UpdateIsOpenAsync(isOpen);
            if(response == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể SubjectId sai"
                }); ;
            }
            return Ok(new
            {
                StatusCode = 200,
                StatusMessage = "Update successfully",
                Response = response
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

        [HttpGet("[action]")]
        public async Task<ActionResult> ListStudentsRegisterSubject([FromQuery]string SubjectId)
        {
            var data = await subjectService.GetSudentRegisteredSubjectBySubjectIdAsync(SubjectId);
            if (data == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể SubjectId"
                });
            }

            return Ok(data);
        }

        

        //[HttpGet("[action]")]
        //public async Task<ActionResult> GetStudentRegisteredSubjectBySubjectId([FromQuery]string subjectId)
        //{
        //    var response = await subjectService.GetSudentRegisteredSubjectBySubjectIdAsync(subjectId);

        //    if(response == null)
        //    {
        //        BadRequest(new
        //        {
        //            Message = "Có thể subjectId sai"
        //        }); ;
        //    }

        //    return Ok(response);
        //}
    }
}
