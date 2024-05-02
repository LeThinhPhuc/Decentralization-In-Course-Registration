namespace BMCSDL.DTOs
{
    public class UpdateMarkForm
    {
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public string ClassroomId { get; set; }
        public string TeacherId { get; set; }
        public string TimeId { get; set; }


        public float Mark1 {  get; set; }       
        public float Mark2 {  get; set; }       
        public float Mark3 {  get; set; }
        //public DateTime RegisterDate { get; set; } = default(DateTime);
    }
}
