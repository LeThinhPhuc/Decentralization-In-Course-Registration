namespace BMCSDL.Models
{
    public class Teacher
    {
        public string TeacherId { get; set; }
        public string PersonId { get; set; }    
        public Person Person { get; set; }

        public ICollection<TeacherSubject> TeacherSubject {  get; set; }    

        public ICollection<TeacherTime> TeacherTime { get; set;}
    }
}
