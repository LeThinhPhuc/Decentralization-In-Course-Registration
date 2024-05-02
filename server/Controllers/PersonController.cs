using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Controllers
{
    public class PersonController : BaseApiController
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }


        [HttpPut("[action]")]
        public async Task<ActionResult> UpdatePersonInformation([FromBody]UpdatePersonInfo updatePersonInfo)
        {
             
            var dataToReturn = await personService.UpdatePersonInformationAsync(updatePersonInfo);    

            if(dataToReturn == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể PersonId hoặc faculty không hợp lệ"
                }); 
            }

            return Ok(new
            {
                StatusMessage = "Update Successfully",
                Info = dataToReturn
            });
        }
    }
}
