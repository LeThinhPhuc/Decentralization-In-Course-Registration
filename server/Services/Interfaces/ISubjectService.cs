using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectDTO3>> GetllAllSubjectsAsync();

        public Task<SubjectDTO> AddNewSubjectAsync(SubjectDTO subjectDTO);  

        public Task<SubjectDTO> DeleteSubjectAsync(string subjectId);


    }
}
    