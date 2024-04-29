using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BMCSDL.Services.Implements
{
    public class SubjectService : ISubjectService
    {
        private readonly CourseRegistraionManagementContext context;
        private readonly IMapper mapper;

        public SubjectService(CourseRegistraionManagementContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<SubjectDTO>> GetllAllSubjectsAsync()
        {
            var subject = await context.Subject
                .Include(s => s.Faculty)
                .Include(s => s.TeacherSubject)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(s => s.Person).ToListAsync();

            var subjectsDTO = this.mapper.Map<IEnumerable<SubjectDTO>>(subject);

            return subjectsDTO; 
        }

        public async Task<SubjectDTO> AddNewSubjectAsync(SubjectDTO subjectDTO)
        {
            var newSubjectId = Guid.NewGuid().ToString();
            subjectDTO.SubjectId = newSubjectId;    
            var subject = new Subject()
            {
                SubjectId = newSubjectId,
                SubjectName = subjectDTO.SubjectName,
                Credits = subjectDTO.Credits,   
                StartDay = subjectDTO.StartDay,
                EndDay = subjectDTO.EndDay,
                FacultyId = subjectDTO.Faculty.FacultyId
            };

            await context.Subject.AddAsync(subject);
            await context.SaveChangesAsync();

            return subjectDTO;
        }

        public async Task<SubjectDTO> DeleteSubjectAsync(string subjectId)
        {
            var subject = await context.Subject.FirstOrDefaultAsync(
                s => s.SubjectId == subjectId);
            
            if(subject != null)
            {
                context.Subject.Remove(subject);    
                context.SaveChanges();
                return this.mapper.Map<SubjectDTO>(subject);    
            }
            return null;
        }

    }
}
