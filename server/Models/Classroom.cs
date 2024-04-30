namespace BMCSDL.Models
{
    public class Classroom
    {
        public string ClassRoomId { get; set; }
        public string ClassroomName { get; set; }
        public int Quantity { get; set; }   

        public ICollection<SubjectClass> SubjectClass { get; set; }

        public ICollection<ClassTime> ClassTime { get; set; }

        public ICollection<StudentRegisteredSubject> StudentRegisteredSubject { get; set; }

    }
}
