using BMCSDL.Models;

namespace BMCSDL.DTOs
{
    public class SubjectDTO
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }

        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public FacultyDTO Faculty { get; set; }

        public ICollection<TeacherSubjectDTO> TeacherSubject {  get; set; }    

    }
}
