using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleAccountDTO2> AssignRoleAsync(RoleAccountDTO2 RoleAccountDTO);
        Task<RoleAccountDTO2> RemoveRoleAsync(RoleAccountDTO2 RoleAccountDTO);

        Task<IEnumerable<object>> GetAllRolesAsync();
<<<<<<< HEAD

        Task<object> UpdateRoleAsync(UpdateRoleDTO updateRole);

        Task<object> UpdateAccountRolesAsync(UpdateAccountRoles accountRoles);

=======
>>>>>>> bdbb170 (first)
    }
}
