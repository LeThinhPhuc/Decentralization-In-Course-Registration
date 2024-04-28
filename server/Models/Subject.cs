namespace BMCSDL.Models
{
    public class Subject
    {
        public string SubjectId {  get; set; }
        public string SubjectName { get; set; } 
        public int Credits { get; set; }
        
        public DateTime StartDay {  get; set; }
        public DateTime EndDay { get; set; }

        public string FacultyId { get; set; }   
        public Faculty Faculty { get; set; }  

        public RegisteredSubject RegisteredSubject { get; set; }    

        public ICollection<SubjectClass> SubjectClass { get; set; }

        public ICollection<TeacherSubject> TeacherSubject { get; set; }

    }
}
