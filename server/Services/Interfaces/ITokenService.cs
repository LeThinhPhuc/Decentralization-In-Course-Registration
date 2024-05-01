using BMCSDL.Models;
using System.IdentityModel.Tokens.Jwt;

namespace BMCSDL.Services.Interfaces
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateJSONWebToken(Account account);

        void SetJWTCookie(string jwtToken);
    }
}
