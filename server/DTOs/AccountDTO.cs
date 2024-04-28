using BMCSDL.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace BMCSDL.DTOs
{
    public class AccountDTO
    {
        public string AccountId { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public RoleDTO Role { get; set; }
    }
}
