namespace BMCSDL.Models
{
    public class RegisteredSubject
    {
        public string RegisteredSubjecId { get; set; }  

        public string SubjectId { get; set; }   
        public Subject Subject { get; set; }    

        public ICollection<StudentRegisteredSubject> Subjects { get; set;}
    }
}
