using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.ReturnModels;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

namespace BMCSDL.Services.Implements
{
    public class AccountService : IAccountService
    {
        private  CourseRegistraionManagementContext context;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AccountService(CourseRegistraionManagementContext context,IMapper mapper,ITokenService tokenService)
        {
            this.context = context;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAccountsAsync()
            {
            var accounts = await context.Account.Include(a => a.Role).ToListAsync();
            var accountsToReturn = this.mapper.Map<List<AccountDTO>>(accounts);
            return accountsToReturn;    

        }

        public  byte[] CaculatePassword(string password, byte[] salt)
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
            var user = await context.Account.Include(a => a.Person)
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
                RoleId = user.RoleId
            };
        }
    }
}
