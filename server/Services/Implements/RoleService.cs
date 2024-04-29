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

            if(isExistedRole != null)
            {
                return null;
            }

            RoleAccount newRoleAccount = new RoleAccount()
            {
                RoleId = RoleAccountDTO.RoleId,
                AccountId = RoleAccountDTO.AccountId,
            };

            await context.RoleAccount.AddAsync(newRoleAccount);
            await context.SaveChangesAsync();

            return RoleAccountDTO;
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

    }
}
