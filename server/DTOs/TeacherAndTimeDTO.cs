namespace BMCSDL.DTOs
{
    public class TeacherAndTimeDTO
    {
        public string TeacherId { get; set; }
        public PersonDTO Person { get; set; }

        public ICollection<RoomTimeSubject> RoomTimeSubject { get; set; }   
    }
}
