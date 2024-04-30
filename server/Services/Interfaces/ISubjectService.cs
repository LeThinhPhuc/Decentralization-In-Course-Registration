using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectDTO3>> GetllAllSubjectsWithScheduleAsync();

        public Task<IEnumerable<object>> GetAllSubjectsAsync();
        public Task<IEnumerable<object>> GetllAllOpenedSubjectsAsync();

        public Task<object> AddNewSubjectAsync(NewSubjectInfo subjectDTO);  

        public Task<SubjectDTO> DeleteSubjectAsync(string subjectId);


    }
}
    