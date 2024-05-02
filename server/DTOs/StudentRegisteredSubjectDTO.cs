using BMCSDL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMCSDL.DTOs
{
    public class StudentRegisteredSubjectDTO
    {
        public StudentDTO Student { get; set; }
        public SubjectDTO Subject { get; set; }

        public float Mark { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
