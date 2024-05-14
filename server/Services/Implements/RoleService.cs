using BMCSDL.DTOs;
using BMCSDL.Migrations;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.ExceptionServices;

namespace BMCSDL.Services.Implements
{
    public class RoleService : IRoleService
    {
        private CourseRegistraionManagementContext context;

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
            var roles = await context.Role.ToListAsync();

            if (roles == null || roles.Count == 0)
            {
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
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    //kiểm tra account có tồn tại không
                    var account = await context.Account
                        .Where(a => a.AccountId == accountRoles.AccountId)
                        .Include(a => a.Person).FirstOrDefaultAsync();

                    if (account == null)
                    {
                        return null;
                    }

                    string personId = account.Person.PersonId;
                    List<RoleAccount> newRoles = new List<RoleAccount>();

                    // Xóa tất cả các role hiện tại của account
                    var existingRoles = context.RoleAccount
                        .Where(ra => ra.AccountId == account.AccountId);
                    context.RoleAccount.RemoveRange(existingRoles);

                    //xóa tất các các loại person
                    var Teacher = await context.Teacher.FirstOrDefaultAsync(t => t.TeacherId == personId);
                    var Giaovu = await context.GiaoVu.FirstOrDefaultAsync(g => g.GiaoVuId == personId);
                    var Truongbomon = await context.TruongBoMon.FirstOrDefaultAsync(t => t.TruongBoMonId == personId);
                    var Truongphokhoa = await context.TruongPhoKhoa.FirstOrDefaultAsync(t => t.TruongPhoKhoaId == personId);
                    var Student = await context.Student.FirstOrDefaultAsync(t => t.StudentId == personId);

                    if(Teacher != null)
                    {
                        context.Teacher.Remove(Teacher);
                    }

                    if(Giaovu != null)
                    {
                        context.GiaoVu.Remove(Giaovu);
                    }

                    if(Truongbomon != null)
                    {
                        context.TruongBoMon.Remove(Truongbomon);    
                    }

                    if(Truongphokhoa != null)
                    {
                        context.TruongPhoKhoa.Remove(Truongphokhoa);
                    }

                    if(Student != null)
                    {
                        context.Student.Remove(Student);
                    }

                    //lấy tất cả các roleId định update
                    foreach (var roleId in accountRoles.RoleIds)
                    {
                        //kiểm trả xem account đã có role đó chưa
                        var roleAccount = await context
                            .RoleAccount
                            .FirstOrDefaultAsync(ra =>
                            ra.AccountId == account.AccountId &&
                            ra.RoleId == roleId);

                        //nếu mà account chưa có role này 
                        //add role mới và trong list
                        newRoles.Add(new RoleAccount
                        {
                            RoleId = roleId,
                            AccountId = account.AccountId
                        });

                        //add loại person vào role tương ứng
                        if (roleId == "giaovien")
                        {
                            var giaovien = new Teacher()
                            {
                                TeacherId = personId,
                                PersonId = personId,
                            };
                            context.Teacher.Add(giaovien);
                        }
                        else if (roleId == "giaovu")
                        {
                            var giaovu = new GiaoVu()
                            {
                                GiaoVuId = personId,
                                PersonId = personId,
                            };
                            context.GiaoVu.Add(giaovu);
                        }
                        else if (roleId == "sinhvien")
                        {
                            var sinhvien = new Student()
                            {
                                StudentId = personId,
                                PersonId = personId
                            };
                            context.Student.Add(sinhvien);
                        }
                        else if (roleId == "truongbomon")
                        {
                            var truongbomon = new TruongBoMon()
                            {
                                TruongBoMonId = personId,
                                PersonId = personId,
                            };
                            context.TruongBoMon.Add(truongbomon);
                        }
                        else if (roleId == "truongphokhoa")
                        {
                            var truongphokhoa = new TruongPhoKhoa()
                            {
                                TruongPhoKhoaId = personId,
                                PersonId = personId,
                            };
                            context.TruongPhoKhoa.Add(truongphokhoa);
                        }
                    }

                    context.RoleAccount.AddRange(newRoles);
                    await context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return accountRoles;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

    }
}
