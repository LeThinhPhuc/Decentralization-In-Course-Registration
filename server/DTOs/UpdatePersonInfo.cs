namespace BMCSDL.DTOs
{
    public class UpdatePersonInfo
    {
        public string PersonId { get; set; }    
        public string FullName { get; set; }    
        public string Gender { get; set; }  
        public string PhoneNumber { get; set; } 

        public DateTime DateOfBirth { get; set; }   
        public string Address { get; set; }
        
        public string FacultyId { get; set; }   
    }
}
