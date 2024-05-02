using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Controllers
{
    public class TimeController : BaseApiController
    {
        private ITimeService timeService;

        public TimeController(ITimeService timeService)
        {
            this.timeService = timeService;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllTime()
        {
            var time = await timeService.GetAllTimeAsync(); 

            if(time == null)
            {
                return NoContent();
            }

            return Ok(time);    

        }


        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewTime([FromBody]NewTimeDTO newTime)
        {
            var time = await timeService.AddTimeAsync(newTime);

            if (time == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể thời gian bị đè"
                });
            }

            return Ok(time);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetTimeById([FromQuery]string timeId)
        {
            var time = await timeService.GetTimeByIdAsync(timeId); 

            if(time == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể timeId không đúng"
                });
            }

            return Ok(time);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteTimeById([FromQuery]string timeId)
        {
            var response = await timeService.DeleteTimeAsync(timeId);

            if (response == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể timeId không đúng"
                });
            }

            return Ok(new
            {
                Message = "Delete successfully",
                Response = response
            });
        }
    }
}
