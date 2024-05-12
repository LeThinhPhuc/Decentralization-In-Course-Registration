namespace BMCSDL.DTOs
{
    public class PersonDTO
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; } = default(DateTime);  
        public string Address { get; set; }
        public string FacultyId { get; set; }
    }
}
