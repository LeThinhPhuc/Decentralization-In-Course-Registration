using BMCSDL.Models;

namespace BMCSDL.DTOs
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<string> RoleId { get; set; }

        public PersonDTO PersonInfo { get; set; }   
    }
}
