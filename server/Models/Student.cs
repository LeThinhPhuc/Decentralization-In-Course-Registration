namespace BMCSDL.Models
{
    public class Student
    {
        public string StudentId {  get; set; }
        public string PersonId { get; set; }    
        public Person Person { get; set; }

        public ICollection<StudentRegisteredSubject> RegisteredSubjects { get; set; }

    }
}
