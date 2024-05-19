using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Implements;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Controllers
{
    public class ScheduleController : BaseApiController
    {
        private  IScheduleService scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }


        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllSchedules()
        {
            var schedules = await scheduleService.GetAllScheduleAsync();
            if(schedules.Count() == 0)
            {
                return NoContent();
            }
            return Ok(schedules);
        }


        [Authorize(Roles ="truongphokhoa,truongbomon")]
        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewSchedule([FromBody]NewScheduleDTO teacherTimeDTO)
        {
            var newTime = await scheduleService.AddNewScheduleAsync(teacherTimeDTO);

            if (newTime == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể id nào đó đã sai hoặc đã có schedule rồi hoặc môn học chưa dược mở"
                });
            }
            return Ok(new
            {
                Status = "Add new schedule successfully",
                NewTime = newTime
            });

        }

        [Authorize(Roles = "truongphokhoa,truongbomon")]
        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteSchedule([FromBody] NewScheduleDTO deleteSchedule)
        {
            var response = await scheduleService.RemoveScheduleAsync(deleteSchedule);
            if(response == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể id nào đó đã sai"
                });
            }

            return Ok(new
            {
                Status = "Delete schedule successfully",
                DeletedTime = response
            });
        }
    }
}
