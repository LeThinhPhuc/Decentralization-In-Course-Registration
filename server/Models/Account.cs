namespace BMCSDL.Models
{
    public class Account
    {
        public string AccountId { get; set; }
        public string UserName { get; set; }
        
        public byte[] PasswordHash {  get; set; }
        public byte[] PasswordSalt { get; set;}

        public string RoleId { get; set; }  
        public Role Role { get; set; }

        public Person Person { get; set; }
    }
}
