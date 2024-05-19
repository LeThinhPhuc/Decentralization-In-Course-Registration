using BMCSDL.DTOs;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "truongphokhoa")]
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
        

        [Authorize]
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateRole([FromBody] UpdateRoleDTO updateRole)
        {

            var response = await roleService.UpdateRoleAsync(updateRole);
            if(response == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể roleId sai hoặc roleName bị trống"
                });
            }

            return Ok(new
            {
                Message = "Update Successfully",
                response = response
            });
        }


        [Authorize(Roles = "truongphokhoa")]
        [HttpPost("[action]")]
        public async Task<ActionResult> UpdateAccountRoles([FromBody] UpdateAccountRoles accountRoles)
        {
            var response  = await roleService.UpdateAccountRolesAsync(accountRoles);

            if(response == null)
            {
                return BadRequest(new
                {
                    Message = "Có thể accountId không tồn tại"
                });
            }
            return Ok(response);
        }
    }
}
