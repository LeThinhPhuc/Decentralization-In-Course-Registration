using BMCSDL.DTOs;
using BMCSDL.ReturnModels;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace BMCSDL.Controllers
{
    public class AuthController : BaseApiController
    {
        private IAccountService accountService;

        public AuthController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAccounts()
        {
            var accountsDTO = await accountService.GetAllAccountsAsync();

            if (accountsDTO.Count() == 0 || accountsDTO == null )
            {
                return BadRequest();
            }

            return Ok(accountsDTO);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login(LoginDTO account)
        {
            UserDTO returnData = await accountService.LoginAsync(account);
            if( returnData != null )
            {
                return Ok(returnData);
            }

            return Unauthorized();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Register([FromBody]UserRegisterDTO user)
        {
            var dataToReturn = await accountService.RegisterAsync(user);
            if(dataToReturn == null )
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
