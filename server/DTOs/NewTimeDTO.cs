namespace BMCSDL.DTOs
{
    public class NewTimeDTO
    {
        public string TimeId { get; set; }
        public string TimeName { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        //public TimeSpan StartTime { get; set; }
        //public TimeSpan EndTime { get; set; }

        public string StartTime { get; set; }   
        public string EndTime { get; set; }
    }
}
