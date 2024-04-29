using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace BMCSDL.Services.Implements
{
    public class StudentService : IStudentService
    {
        private CourseRegistraionManagementContext context;
        private readonly IMapper mapper;

        public StudentService(CourseRegistraionManagementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<SubjectDTO> RegisterSubjectAsync(RegistrationSubjectFormDTO regisForm)
        {

            var isRegisteredSubject = await context.StudentRegisteredSubject
                .FirstOrDefaultAsync(e => e.StudentId == regisForm.StudentId && e.SubjectId == regisForm.SubjectId);

            if (isRegisteredSubject != null)
            {
                return null;
            }

            var newRegistrationSubject = new StudentRegisteredSubject()
            {
                StudentId = regisForm.StudentId,
                SubjectId = regisForm.SubjectId,
                Mark = 0,
                RegisterDate = DateTime.Now,
            };

            context.StudentRegisteredSubject.Add(newRegistrationSubject);
            context.SaveChanges();
            var subject = await context.Subject.FirstOrDefaultAsync(s => s.SubjectId == regisForm.SubjectId);

            return mapper.Map<SubjectDTO>(subject);


        }

        public async Task<SubjectDTO> RemoveRegisteredSubjectAsync(RegistrationSubjectFormDTO regisForm)
        {
            var registeredSubject = await context
                .StudentRegisteredSubject
                .FirstOrDefaultAsync(s => s.StudentId == regisForm.StudentId && s.SubjectId == regisForm.SubjectId);

            if (registeredSubject == null)
            {
                return null;
            }

            context.StudentRegisteredSubject.Remove(registeredSubject);
            await context.SaveChangesAsync();
            var subject = await context.Subject.FirstOrDefaultAsync(s => s.SubjectId == regisForm.SubjectId);

            var subjectDTO = mapper.Map<SubjectDTO>(subject);
            return subjectDTO;  

        }

        public async Task<IEnumerable<StudentRegisteredSubjectDTO>> GetRegisteredSubjectsAsync(string studentId)
        {
            var registeredSubjects = await context.StudentRegisteredSubject
                .Where(s => s.StudentId == studentId)
                .Include(s => s.Subject).ToListAsync();


            if (registeredSubjects.Count() == 0 || registeredSubjects == null)
            {
                return null;
            }

            return mapper.Map<IEnumerable<StudentRegisteredSubjectDTO>>(registeredSubjects);

        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var students = await context.Student.Include(s => s.Person).ToListAsync();


            return mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetStudentByIdAsync(string studentId)
        {
            var student = await context.Student
                .Include(s => s.Person)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            return mapper.Map<StudentDTO>(student); 


        }


    }
}
