namespace BMCSDL.Models
{
    public class TeacherSubject
    {
        public string TeacherId { get; set; }
        public string SubjectId { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
