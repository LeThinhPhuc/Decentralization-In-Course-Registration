using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

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

        public async Task<IEnumerable<object>> GetAllSubjectsAsync()
        {
            var subjects = await context.Subject.Include(s => s.Faculty).ToListAsync();

            if(!subjects.Any())
            {
                return null;
            }

            var dataToReturn = subjects.Select(s => new
            {
                SubjectId = s.SubjectId,
                SubjectName = s.SubjectName,
                Credits = s.Credits,
                StartDay = s.StartDay,
                EndDay = s.EndDay,
                Open = s.isOpen,
                Faculty = new
                {
                    FacultyId = s.Faculty.FacultyId,
                    FacultyName = s.Faculty.FacultyName
                }
            });


            return new List<object>(dataToReturn);  
        }


        public async Task<IEnumerable<SubjectDTO3>> GetllAllSubjectsWithScheduleAsync()
        {

            var subjects = await context.Subject
                .Include(s => s.Faculty)
                .Include(s => s.SubjectClass)
                .ThenInclude(s => s.Classroom)
                .Include(s => s.SubjectClass)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(t => t.Person)
                .Include(s => s.SubjectClass)
                .ThenInclude(s => s.Time)
                .ToListAsync();

            var subjectDTO2 = subjects.Select(s => new SubjectDTO3()
            {
                SubjectId = s.SubjectId,
                SubjectName = s.SubjectName,
                Credits = s.Credits,
                StartDay = s.StartDay,
                EndDay = s.EndDay,
                Faculty = new FacultyDTO()
                {
                    FacultyId = s.Faculty.FacultyId,
                    FacultyName = s.Faculty.FacultyName
                },
                SubjectClass = s.SubjectClass.Select(s => new SubjectClassDTO2()
                {
                    Classroom = new ClassroomDTO()
                    {
                        ClassRoomId = s.Classroom.ClassRoomId,
                        ClassroomName = s.Classroom.ClassroomName,
                    },
                    Time = new TimeDTO()
                    {
                        TimeId = s.Time.TimeId,
                        TimeName = s.Time.TimeName, 
                        DayOfWeek = s.Time.DayOfWeek,
                        StartTime = s.Time.StartTime,
                        EndTime = s.Time.EndTime,
                    },
                    Teacher = new TeacherDTO2()
                    {
                        TeacherId = s.Teacher.TeacherId,
                        TeacherName = s.Teacher.Person.FullName
                    }
                }).ToList()
            }); ;

            return subjectDTO2;
        }

        public async Task<IEnumerable<object>> GetllAllOpenedSubjectsAsync()
        {
            var subjects = await context.Subject.Include(s => s.Faculty).Where(s => s.isOpen == true).ToListAsync();

            if (!subjects.Any())
            {
                return null;
            }

            var dataToReturn = subjects.Select(s => new
            {
                SubjectId = s.SubjectId,
                SubjectName = s.SubjectName,
                Credits = s.Credits,
                StartDay = s.StartDay,
                EndDay = s.EndDay,
                Open = s.isOpen,
                Faculty = new
                {
                    FacultyId = s.Faculty.FacultyId,
                    FacultyName = s.Faculty.FacultyName
                }
            });


            return new List<object>(dataToReturn);
        }

        public async Task<object> AddNewSubjectAsync(NewSubjectInfo subjectDTO)
        {
            var isExistedSubject = await context.Subject.FirstOrDefaultAsync(s => s.SubjectName == subjectDTO.SubjectName); 

            if (isExistedSubject != null)
            {
                return null;
            }

            var isExistedFaculty = await context.Faculty.FirstOrDefaultAsync(s => s.FacultyId == subjectDTO.FacultyId);
            if(isExistedFaculty == null)
            {
                return null;
            }

            var newSubjectId = Guid.NewGuid().ToString();
            var subject = new Subject()
            {
                SubjectId = newSubjectId,
                SubjectName = subjectDTO.SubjectName,
                Credits = subjectDTO.Credits,   
                StartDay = subjectDTO.StartDay,
                EndDay = subjectDTO.EndDay,
                FacultyId = subjectDTO.FacultyId
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
