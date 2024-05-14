namespace BMCSDL.DTOs
{
    public class UpdateAccountRoles
    {
        public string AccountId { get; set; }   

        public ICollection<string> RoleIds { get; set; } 
    }
}
