namespace BMCSDL.Models
{
    public class Faculty
    {
        public string FacultyId {  get; set; }
        public string FacultyName { get; set; }
        public string ContactInformation { get; set; }  

        public ICollection<Person> Person { get; set; }
        public ICollection<Subject> Subject  { get; set; }
    }
}
