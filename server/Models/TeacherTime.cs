using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMCSDL.Models
{
    public class TeacherTime
    {
        [Key, Column(Order = 0)]
        public string TeacherId { get; set; }
        [Key, Column(Order = 1)]
        public string TimeId { get; set; }

        public Teacher Teacher { get; set; }    
        
        public Time Time { get; set; }
    }
}
