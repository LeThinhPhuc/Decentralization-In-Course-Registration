using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Controllers
{
    public class ClassroomController : BaseApiController
    {
        private IClassroomService classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            this.classroomService = classroomService;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllClassrooms()
        {
            var classrooms = await classroomService.GetAllClassroomsAsync();

            if (classrooms == null || classrooms.Count() == 0)
            {
                return NoContent();
            }

            return Ok(classrooms);
        }



        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewClassroom([FromBody] NewClassroomDTO newClassroom)
        {
            var response = await classroomService.AddNewClassroomAsync(newClassroom);

            if(response == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể tên phòng bị trùng"
                });
            }

            return Ok(new
            {
                StatusCode = 200,
                StatusMessage = "Add new classroom successfully",
                Response = response 
            });    
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteClassroom([FromQuery] string classroomId)
        {
            var response = await classroomService.RemoveClassroomAsync(classroomId);
            if( response == null )
            {
                return BadRequest(new
                {
                    Message = "Có thể sai classroomId"
                });
            }
            return Ok(new
            {
                Message = "Delete successfully",
                Classroom = response
            });
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateClassroom([FromBody] NewClassroomDTO newInfoClassroom)
        {

            var response = await classroomService.UpdateClassroomAsync(newInfoClassroom);
            if (response == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể sai classroomId hoặc trùng ClassroomName"
                });
            }

            return Ok(new
            {
                Message = "Update successfully",
                Classroom = response
            });
        }
    }
}
