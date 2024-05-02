using BMCSDL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BMCSDL.Services.Interfaces
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectDTO3>> GetllAllSubjectsWithScheduleAsync();

        public Task<IEnumerable<object>> GetAllSubjectsAsync();
        public Task<IEnumerable<object>> GetllAllOpenedSubjectsAsync();

        public Task<object> AddNewSubjectAsync(NewSubjectInfo subjectDTO);  

        public Task<SubjectDTO> DeleteSubjectAsync(string subjectId);

        public Task<object> UpdateSubjectAsync(UpdateSubjectInfo subjectDTO);
        public Task<object> UpdateIsOpenAsync(OpenCloseSubject subjectDTO);

        public Task<object> GetSudentRegisteredSubjectBySubjectIdAsync(string SubjectId);

        public Task<object> UpdateMarkAsync(UpdateMarkForm updateMark);


    }
}
    