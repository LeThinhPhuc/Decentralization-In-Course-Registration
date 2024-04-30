namespace BMCSDL.DTOs
{
    public class SubjectDTO3
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }

        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public FacultyDTO Faculty { get; set; }

        public ICollection<SubjectClassDTO2> SubjectClass { get; set; }    
    }
}
