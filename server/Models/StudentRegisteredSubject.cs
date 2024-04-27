using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMCSDL.Models
{
    public class StudentRegisteredSubject
    {
        [Key, Column(Order = 0)]
        public string StudentId { get; set; }
        [Key, Column(Order = 1)]
        public string RegisteredSubjectId { get; set; }

        public Student Student { get; set; }    
        public RegisteredSubject RegisteredSubject { get; set; }    

        public float Mark { get; set; }    
    }
}
