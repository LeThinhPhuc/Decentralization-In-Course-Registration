using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleAccountDTO2> AssignRoleAsync(RoleAccountDTO2 RoleAccountDTO);
        Task<RoleAccountDTO2> RemoveRoleAsync(RoleAccountDTO2 RoleAccountDTO);
    }
}
