namespace BMCSDL.Models
{
    public class Time
    {
        public string TimeId { get; set; }
        public string TimeName { get; set; }
        
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }

        public ICollection<ClassTime> ClassTime { get; set; }   

        public ICollection<SubjectClass> SubjectClass { get; set; } 
    }
}
