namespace BMCSDL.Models
{
    public class ClassTime
    {
        public string ClassroomId {  get; set; }
        public string TimeId {  get; set; } 

        public Classroom Classroom { get; set; }
        public Time Time { get; set; }  
    }
}
