using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BMCSDL.Services.Implements
{
    public class RoleService : IRoleService
    {
        private  CourseRegistraionManagementContext context;

        public RoleService(CourseRegistraionManagementContext context)
        {
            this.context = context;
        }
        public async Task<RoleAccountDTO2> AssignRoleAsync(RoleAccountDTO2 RoleAccountDTO)
        {
            var isExistedRole = await context.RoleAccount
                .FirstOrDefaultAsync(ra => ra.RoleId == RoleAccountDTO.RoleId && 
                ra.AccountId == RoleAccountDTO.AccountId);
            

            RoleAccount newRoleAccount = new RoleAccount()
            {
                RoleId = RoleAccountDTO.RoleId,
                AccountId = RoleAccountDTO.AccountId,
            };

            await context.RoleAccount.AddAsync(newRoleAccount);
            await context.SaveChangesAsync();

            return RoleAccountDTO;
        }

        public async Task<IEnumerable<object>> GetAllRolesAsync()
        {
            var roles =  await context.Role.ToListAsync();

            if(roles == null || roles.Count == 0) {
                return null;
            }

            var dataToReturn = roles.Select(r => new
            {
                roleId = r.RoleId,
                roleName = r.RoleName,
            });

            return dataToReturn;
        }

        public async Task<RoleAccountDTO2> RemoveRoleAsync(RoleAccountDTO2 RoleAccountDTO)
        {

            var isExistedRole = await context.RoleAccount
                .FirstOrDefaultAsync(ra => ra.RoleId == RoleAccountDTO.RoleId && ra.AccountId == RoleAccountDTO.AccountId);


            //nếu có role thì != null
            if (isExistedRole != null)
            {
                context.RoleAccount.Remove(isExistedRole);
                await context.SaveChangesAsync();
                return RoleAccountDTO;
            }
            return null;
        }

        public async Task<object> UpdateRoleAsync(UpdateRoleDTO updateRole)
        {
            var role = await context.Role
                .FirstOrDefaultAsync(r => r.RoleId == updateRole.RoleId);

            if (role == null)
            {
                return null;
            }


            if (!String.IsNullOrEmpty(updateRole.RoleName))
            {
                role.RoleName = updateRole.RoleName;
            }
            else return null;

            context.Role.Update(role);
            context.SaveChanges();

            return updateRole;
        }


        public async Task<object> UpdateAccountRolesAsync(UpdateAccountRoles accountRoles)
        {
            var account = await context.Account
                .FirstOrDefaultAsync(a => a.AccountId == accountRoles.AccountId);

            if(account == null)
            {
                return null;
            }

            foreach(var roleId in accountRoles.RoleIds)
            {
                var roleAccount = await context
                    .RoleAccount
                    .FirstOrDefaultAsync(ra => ra.AccountId == account.AccountId
                    && ra.RoleId == roleId);

                //nếu mà account chưa có role này 
                //List<RoleAccount>
                //if(roleAccount == null)
                //{
                    
                //}
            }

            return null;
        }


    }
}
