using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize]
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


        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllPersons()
        {
            var people = await personService.GetAllPersonsAsync();  
            return Ok(people);
        }



        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetPersonById([FromQuery]string personId)
        {
            var person = await personService.GetPersonByIdAsync(personId);
            if(person == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể personId sai"
                });
            }

            return Ok(person);
        }

    }
}
