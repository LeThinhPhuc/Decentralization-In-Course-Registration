namespace BMCSDL.Models
{
    public class Person
    {
        public string PersonId { get; set; }    
        public string FullName { get; set; }
        public string Gender { get; set; }  
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public string Address { get; set; } 

        public Account Account { get; set; }
        public Faculty Faculty { get; set; }

        public Student Student { get; set; }
        public TruongPhoKhoa TruongPhoKhoa { get; set; }
        public TruongBoMon TruongBoMon { get; set; }
        public GiaoVu GiaoVu { get; set; }
        public Teacher Teacher { get; set; }

        public string AccountId { get; set; }
        public string FacultyId { get; set; }   

    }
}
