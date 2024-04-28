namespace BMCSDL.Models
{
    public class Account
    {
        public string AccountId { get; set; }
        public string UserName { get; set; }
        
        public byte[] PasswordHash {  get; set; }
        public byte[] PasswordSalt { get; set;}

        public ICollection<RoleAccount> RoleAccount { get; set; }

        public Person Person { get; set; }
    }
}
