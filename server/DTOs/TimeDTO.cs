namespace BMCSDL.DTOs
{
    public class TimeDTO
    {
        public string TimeId { get; set; }
        public string TimeName { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
