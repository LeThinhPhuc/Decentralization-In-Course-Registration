using BMCSDL.Models;

namespace BMCSDL.DTOs
{
    public class SubjectClassDTO
    {
        public SubjectDTO Subject { get; set; }
        public ClassroomDTO Classroom { get; set; }
        public TimeDTO Time { get; set; }
        public TeacherDTO Teacher { get; set; }
    }
}
