using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMCSDL.Models
{
    public class RoleAccount
    {
        [Key, Column(Order = 0)]
        public string RoleId { get; set; }
        [Key, Column(Order = 1)]
        public string AccountId { get; set; }

        public Role Role { get; set; }
        public Account Account { get; set; }
    }
}
