﻿namespace BMCSDL.DTOs
{
    public class UpdateSubjectInfo
    {
        public string SubjectId { get; set; } 
        public string SubjectName { get; set; } 
        public int Credits { get; set; }
        public DateTime StartDay { get; set; }  
        public DateTime EndDay { get; set; }
        public string FacultyId { get; set; }
        public bool isOpen { get; set; }  
    }
}
