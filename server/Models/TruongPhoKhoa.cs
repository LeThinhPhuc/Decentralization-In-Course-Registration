namespace BMCSDL.Models
{
    public class TruongPhoKhoa
    {
        public string TruongPhoKhoaId { get; set; } 
        
        public string PersonId { get; set; }    
        public Person Person { get; set; }
    }
}
