﻿using AutoMapper;
using AutoMapper.Execution;
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
            var isExistedAccount = await context.Account
                .FirstOrDefaultAsync(a => a.UserName == userRegisterDTO.UserName);
            
            if(isExistedAccount != null)
            {
                return null;
            }
            
            string accountId = Guid.NewGuid().ToString();
            var salt = GenerateSalt();
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
                    PersonId = Guid.NewGuid().ToString(),
                    FullName = userRegisterDTO.PersonInfo.FullName,
                    Gender = userRegisterDTO.PersonInfo.Gender,
                    PhoneNumber = userRegisterDTO.PersonInfo.PhoneNumber,
                    DateOfBirth = userRegisterDTO.PersonInfo.DateOfBirth,
                    Address = userRegisterDTO.PersonInfo.Address,
                    AccountId = accountId,
                    FacultyId = userRegisterDTO.PersonInfo.FacultyId
                }
            };

            await context.Account.AddAsync(newAccount);
            await context.SaveChangesAsync();

            return userRegisterDTO;
        }

    }
}
