using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace BMCSDL.Controllers
{
    public class RoleController : BaseApiController
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllRoles()
        {
            var roles =  await roleService.GetAllRolesAsync();

            if(roles == null)
            {
                return NoContent();
            }
            return Ok(roles);

        }


        [HttpPost("[action]")]
        public async Task<ActionResult> AssignRole([FromBody] RoleAccountDTO2 roleDTO)
        {
            var newRole = await roleService.AssignRoleAsync(roleDTO);  
            if(newRole == null)
            {
                return BadRequest();
            }

            return Ok(roleDTO);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteRole([FromBody] RoleAccountDTO2 roleDTO)
        {
            var newRole = await roleService.RemoveRoleAsync(roleDTO);
            if (newRole == null)
            {
                return BadRequest();
            }

            return Ok(roleDTO);
        }
    }
}
