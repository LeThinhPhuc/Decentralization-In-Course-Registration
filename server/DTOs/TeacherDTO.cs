using BMCSDL.Models;

namespace BMCSDL.DTOs
{
    public class TeacherDTO
    {
        public string TeacherId { get; set; }
        public PersonDTO Person { get; set; }
        public FacultyDTO Faculty { get; set; }


    }
}
