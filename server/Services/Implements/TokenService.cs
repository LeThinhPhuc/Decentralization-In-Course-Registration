using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BMCSDL.Services.Implements
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;
        //private readonly IHttpContextAccessor httpContextAccessor;

        public TokenService(IConfiguration config)
        {
            this.config = config;
        }
        public JwtSecurityToken GenerateJSONWebToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:secret_key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("facultyId",account.Person.Faculty.FacultyId),
                new Claim("username",account.UserName),
                new Claim("accountId",account.Person.AccountId),
                new Claim("personId",account.Person.PersonId),
                new Claim("fullName",account.Person.FullName)
            };

            foreach(var claim in account.RoleAccount) 
            { 
                claims.Add(new Claim("roles",claim.RoleId));
            }

            var token = new JwtSecurityToken(
                    issuer: config["JWTSettings:issuer"],
                    audience: config["JWTSettings:audience"],
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: credentials,
                    claims : claims
                ) ;
            return token;

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public void SetJWTCookie(string jwtToken)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = DateTime.UtcNow.AddHours(3),
        //    };
        //    httpContextAccessor.HttpContext.Response.Cookies.Append("jwtCookie", jwtToken, cookieOptions);
        //}

    }
}
