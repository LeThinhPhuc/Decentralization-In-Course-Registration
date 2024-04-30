using BMCSDL.Models;

namespace BMCSDL.DTOs
{
    public class StudentDTO
    {
        public string StudentId { get; set; }
        public PersonDTO Person { get; set; }

        public FacultyDTO Faculty { get; set; }
    }
}
