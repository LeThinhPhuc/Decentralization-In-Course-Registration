namespace BMCSDL.Models
{
    public class Role
    {
        public string RoleId {  get; set; } 
        public string RoleName { get; set; }

        public Account Account { get; set; }    
    }
}
