using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectDTO>> GetllAllSubjectsAsync();

        public Task<SubjectDTO> AddNewSubjectAsync(SubjectDTO subjectDTO);  

        public Task<SubjectDTO> DeleteSubjectAsync(string subjectId);


    }
}
    