using AutoMapper;
using AutoMapper.Execution;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.ReturnModels;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

namespace BMCSDL.Services.Implements
{
    public class AccountService : IAccountService
    {
        private CourseRegistraionManagementContext context;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AccountService(CourseRegistraionManagementContext context, IMapper mapper, ITokenService tokenService)
        {
            this.context = context;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAccountsAsync()
        {
            var accounts = await context.Account
                .Include(a => a.RoleAccount)
                .ThenInclude(ra => ra.Role)
                .ToListAsync();
            var accountsToReturn = this.mapper.Map<List<AccountDTO>>(accounts);
            return accountsToReturn;

        }

        public byte[] CaculatePassword(string password, byte[] salt)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return hashBytes;
            }
        }

        public async Task<UserDTO> LoginAsync(LoginDTO account)
        {
            var user = await context.Account
                .Include(a => a.Person)
                .ThenInclude(p => p.Faculty)
                .Include(a => a.RoleAccount)  
                .FirstOrDefaultAsync(a => a.UserName == account.username);


            if (user == null)
            {
                return null;
            }

            //lấy salt + password đem hash rồi so sánh hashedPassword

            var hashedPassword = CaculatePassword(account.password, user.PasswordSalt);

            for (int i = 0; i < hashedPassword.Length; i++)
            {
                if (hashedPassword[i] != user.PasswordHash[i])
                {
                    return null;
                }
            }

            var jwt = tokenService.GenerateJSONWebToken(user);
            var stringJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new UserDTO()
            {
                UserName = account.username,
                Token = stringJwt,
            };
        }


        public byte[] GenerateSalt()
        {
            using var hmac = new HMACSHA256();

            return hmac.Key;
        }

       
        public async Task<UserRegisterDTO> RegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            //nếu bất kì 1 role nào không có thì return null
            foreach(var role in userRegisterDTO.RoleId)
            {
                var isExistedRole = await context.Role.FirstOrDefaultAsync(r => r.RoleId == role);
                if(isExistedRole == null)
                {
                    return null;
                }
            }

            //kiểm tra faculty có tồn tại không
            var isExistedFaculty = await context.Faculty.FirstOrDefaultAsync(f => f.FacultyId == userRegisterDTO.PersonInfo.FacultyId);

            if (isExistedFaculty == null)
            {
                return null;
            }

            ////kiểm tra có nhập đủ không tin không
            //if(String.IsNullOrEmpty(userRegisterDTO.UserName))
            //{
            //    return null;
            //}

            //if (String.IsNullOrEmpty(userRegisterDTO.Password))
            //{
            //    return null;
            //}

            //if (String.IsNullOrEmpty(userRegisterDTO.PersonInfo.FullName))
            //{
            //    return null;
            //}


            //if (String.IsNullOrEmpty(userRegisterDTO.PersonInfo.Gender))
            //{
            //    return null;
            //}

            //if (String.IsNullOrEmpty(userRegisterDTO.PersonInfo.PhoneNumber))
            //{
            //    return null;
            //}

            //if (userRegisterDTO.PersonInfo.DateOfBirth == null || userRegisterDTO.PersonInfo.DateOfBirth == default(DateTime))
            //{
            //    return null;
            //}

            //if (String.IsNullOrEmpty(userRegisterDTO.PersonInfo.Address))
            //{
            //    return null;
            //}



            var isExistedAccount = await context.Account
                .FirstOrDefaultAsync(a => a.UserName == userRegisterDTO.UserName);
            
            if(isExistedAccount != null)
            {
                return null;
            }
            
            string accountId = Guid.NewGuid().ToString();
            var salt = GenerateSalt();
            string personId = Guid.NewGuid().ToString();
            Account newAccount = new Account()
            {
                AccountId = accountId,
                UserName = userRegisterDTO.UserName,
                PasswordHash = CaculatePassword(userRegisterDTO.Password, salt),
                PasswordSalt = salt ,
                RoleAccount = userRegisterDTO.RoleId.Select(r => new RoleAccount()
                {
                    RoleId = r,
                    AccountId = accountId
                }).ToList(),
                Person = new Person()
                {
                    PersonId = personId,
                    FullName = userRegisterDTO.PersonInfo.FullName,
                    Gender = userRegisterDTO.PersonInfo.Gender,
                    PhoneNumber = userRegisterDTO.PersonInfo.PhoneNumber,
                    DateOfBirth = userRegisterDTO.PersonInfo.DateOfBirth,
                    Address = userRegisterDTO.PersonInfo.Address,
                    AccountId = accountId,
                    FacultyId = userRegisterDTO.PersonInfo.FacultyId
                }
            };

            foreach(var role in userRegisterDTO.RoleId)
            {
                if(role == "giaovien")
                {
                    var giaovien = new Teacher()
                    {
                        TeacherId = personId,
                        PersonId = personId,
                    };
                    context.Teacher.Add(giaovien);
                }

                else if(role == "giaovu")
                {
                    var giaovu = new GiaoVu()
                    {
                        GiaoVuId = personId,
                        PersonId = personId,
                    };
                    context.GiaoVu.Add(giaovu);
                }

                else if(role == "sinhvien")
                {
                    var sinhvien = new Student()
                    {
                        StudentId = personId,
                        PersonId = personId
                    };
                    context.Student.Add(sinhvien);
                }

                else if(role == "truongbomon")
                {
                    var truongbomon = new TruongBoMon()
                    {
                        TruongBoMonId = personId,
                        PersonId = personId,
                    };
                    context.TruongBoMon.Add(truongbomon);
                }

                else if(role == "truongphokhoa")
                {
                    var truongphokhoa = new TruongPhoKhoa()
                    {
                        TruongPhoKhoaId = personId,
                        PersonId = personId,
                    };
                    context.TruongPhoKhoa.Add(truongphokhoa);   
                }
            }

            await context.Account.AddAsync(newAccount);
            await context.SaveChangesAsync();

            return userRegisterDTO;
        }

        public async Task<object> DeleteAccountAsync(string accountId)
        {
            Account account =  await context.Account.FirstOrDefaultAsync(a => a.AccountId == accountId);

            if(account == null)
            {
                return null;
            }

            context.Account.Remove(account);
            context.SaveChanges();

            return new
            {
                AccountId = account.AccountId,
                UserName = account.UserName
            };
        }
    }
}
