using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMCSDL.Models
{
    public class StudentRegisteredSubject
    {
        [Key, Column(Order = 0)]
        public string StudentId { get; set; }

        [Key, Column(Order = 1)]
        public string SubjectId { get; set; }

        [Key, Column(Order = 2)]
        public string ClassroomId { get; set; }

        [Key, Column(Order = 3)]
        public string TimeId { get; set; }

        [Key, Column(Order = 4)]
        public string TeacherId { get; set; }   

        public Student Student { get; set; }    
        public Subject Subject { get; set; }   
        
        public Classroom Classroom { get; set; }
        public Time Time { get; set; }  
        public Teacher Teacher { get; set; }    

        public float Mark1 { get; set; }    
        public float Mark2 { get; set; }    
        public float Mark3 { get; set; }    

        public DateTime RegisterDate { get; set; }  
    }
}
