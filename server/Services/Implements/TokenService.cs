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
        private readonly IHttpContextAccessor httpContextAccessor;

        public TokenService(IConfiguration config,IHttpContextAccessor httpContextAccessor)
        {
            this.config = config;
            this.httpContextAccessor = httpContextAccessor;
        }
        public JwtSecurityToken GenerateJSONWebToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:secret_key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,account.RoleId),
                new Claim(ClaimTypes.Name,account.Person.FullName),
                new Claim(ClaimTypes.NameIdentifier,account.Person.AccountId)
            };

            var token = new JwtSecurityToken(
                    issuer: config["JWTSettings:issuer"],
                    audience: config["JWTSettings:issuer"],
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: credentials,
                    claims : claims
                ) ;
            return token;

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void SetJWTCookie(string jwtToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(3),
            };
            httpContextAccessor.HttpContext.Response.Cookies.Append("jwtCookie", jwtToken, cookieOptions);
        }

    }
}
