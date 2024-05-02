using BMCSDL.DTOs;
using BMCSDL.Services.Implements;
using BMCSDL.Services.Interfaces;
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

        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewSchedule([FromBody]NewScheduleDTO teacherTimeDTO)
        {
            var newTime = await scheduleService.AddNewScheduleAsync(teacherTimeDTO);

            if (newTime == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Status = "Add new time successfully",
                NewTime = newTime
            });

        }
    }
}
