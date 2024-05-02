namespace BMCSDL.Models
{
    public class Role
    {
        public string RoleId {  get; set; } 
        public string RoleName { get; set; }

        public ICollection<RoleAccount> RoleAccount { get; set; }    
    }
}
