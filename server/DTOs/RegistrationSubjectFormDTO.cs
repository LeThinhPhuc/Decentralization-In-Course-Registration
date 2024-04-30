namespace BMCSDL.DTOs
{
    public class RegistrationSubjectFormDTO
    {
        public string StudentId { get; set; }   


        //học sinh đăng kí môn cần quan tâm 4 cái này
        public string SubjectId {  get; set; }
        public string ClassroomId { get; set; } 
        public string TeacherId { get; set; }
        public string TimeId {get; set; }
    }
}
