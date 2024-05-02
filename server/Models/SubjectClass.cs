using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMCSDL.Models
{
    public class SubjectClass
    {
        [Key, Column(Order = 0)]
        public string SubjectId {  get; set; }

        [Key, Column(Order = 1)]
        public string ClassroomId { get; set; }

        [Key, Column(Order = 2)]
        public string TimeId { get; set; }

        [Key, Column(Order = 3)]
        public string TeacherId { get; set; }   

        public Subject Subject { get; set; }
        public Classroom Classroom { get; set; }
        public Time Time { get; set; }  
        public Teacher Teacher { get; set;}

    }
}
