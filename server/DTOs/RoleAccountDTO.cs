using BMCSDL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMCSDL.DTOs
{
    public class RoleAccountDTO
    {
        public string RoleId { get; set; }
        public string AccountId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
