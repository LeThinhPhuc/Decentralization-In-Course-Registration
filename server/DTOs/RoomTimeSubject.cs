using BMCSDL.Models;

namespace BMCSDL.DTOs
{
    public class RoomTimeSubject
    {
        public ClassroomDTO Classroom { get; set; }
        public TimeDTO Time { get; set; }

        public SubjectDTO2 Subject { get; set; }
    }
}
