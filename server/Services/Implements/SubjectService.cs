using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace BMCSDL.Services.Implements
{
    public class SubjectService : ISubjectService
    {
        private readonly CourseRegistraionManagementContext context;
        private readonly IMapper mapper;

        public SubjectService(CourseRegistraionManagementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<object>> GetAllSubjectsAsync()
        {
            var subjects = await context.Subject.Include(s => s.Faculty).ToListAsync();

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


        public async Task<IEnumerable<object>> GetllAllSubjectsWithScheduleAsync()
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

            var subjectDTO2 = subjects.Select(s => new 
            {
                SubjectId = s.SubjectId,
                SubjectName = s.SubjectName,
                Credits = s.Credits,
                StartDay = s.StartDay,
                EndDay = s.EndDay,
                isOpen = s.isOpen,
                Faculty = new FacultyDTO()
                {
                    FacultyId = s.Faculty.FacultyId,
                    FacultyName = s.Faculty.FacultyName
                },
                SubjectClass = s.SubjectClass.Select(s => new 
                {
                    Classroom = new 
                    {
                        ClassRoomId = s.Classroom.ClassRoomId,
                        ClassroomName = s.Classroom.ClassroomName,
                        MaxQuantity = s.Classroom.MaxQuantity
                    },
                    Time = new 
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
            var subjects = await context.Subject
                .Where(s => s.isOpen == true)
                .Include(s => s.SubjectClass)
                .ThenInclude(s => s.Classroom)
                .Include(s => s.SubjectClass)
                .ThenInclude(s => s.Time)
                .Include(s => s.SubjectClass)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(t => t.Person)
                .Include(s => s.Faculty).ToListAsync();

            
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
                },

                Schedule = s.SubjectClass.Select(s => new
                {
                    Classroom = new
                    {
                        ClassroomId = s.Classroom.ClassRoomId,
                        ClassroomName = s.Classroom.ClassroomName,
                    },
                    Time = new
                    {
                        TimeId = s.Time.TimeId,
                        DayOk = s.Time.DayOfWeek,
                        StartTIme = s.Time.StartTime,
                        EndTim = s.Time.EndTime
                    },
                    Teacher = new
                    {
                        TeacherId = s.Teacher.TeacherId,
                        TeacherName = s.Teacher.Person.FullName
                    },
                    Slot = new
                    {
                        CurrentQuantity = s.CurrentQuantity,
                        MaxQuantity = s.Classroom.MaxQuantity
                    }
                })
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
            if (isExistedFaculty == null)
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

        public async Task<object> UpdateSubjectAsync(UpdateSubjectInfo subjectDTO)
        {
            if (subjectDTO.FacultyId != null)
            {
                var isExistedFaculty = await context.Faculty
                    .FirstOrDefaultAsync(s => s.FacultyId == subjectDTO.FacultyId);

                if (isExistedFaculty == null)
                {
                    return null;
                }
            }

            var isExistedSubject = await context.Subject
                .FirstOrDefaultAsync(s => s.SubjectId == subjectDTO.SubjectId);

            if (isExistedSubject == null)
            {
                return null;
            }

            if(subjectDTO.isOpen == true || subjectDTO.isOpen == false)
            {
                isExistedSubject.isOpen = subjectDTO.isOpen;
            }

            if (!string.IsNullOrEmpty(subjectDTO.SubjectName))
            {
                isExistedSubject.SubjectName = subjectDTO.SubjectName;
            }
            if (subjectDTO.Credits != 0)//create != 0 thì cấp nhập
            {
                isExistedSubject.Credits = subjectDTO.Credits;
            }
            if (subjectDTO.StartDay != default(DateTime)) //StartDay khác DateTime mặc định thì cập nhật
            {
                isExistedSubject.StartDay = subjectDTO.StartDay;
            }
            if (subjectDTO.EndDay != default(DateTime))// EndDay khác DateTime mặc định thì cập nhật
            {
                isExistedSubject.EndDay = subjectDTO.EndDay;
            }
            if (subjectDTO.FacultyId != null)
            {
                isExistedSubject.FacultyId = subjectDTO.FacultyId;
            }


            context.Subject.Update(isExistedSubject);

            await context.SaveChangesAsync();

            return subjectDTO;

        }


        public async Task<SubjectDTO> DeleteSubjectAsync(string subjectId)
        {
            var subject = await context.Subject.FirstOrDefaultAsync(
                s => s.SubjectId == subjectId);

            if (subject != null)
            {
                context.Subject.Remove(subject);
                context.SaveChanges();
                return this.mapper.Map<SubjectDTO>(subject);
            }
            return null;
        }

       

        public async Task<object> GetSudentRegisteredSubjectBySubjectIdAsync(string SubjectId)
        {
            var subject = await context
                .Subject.Where(s => s.SubjectId == SubjectId)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Student)
                .ThenInclude(s => s.Person)
                .ThenInclude(p => p.Account)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Classroom)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Time)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(s => s.Person)
                .FirstOrDefaultAsync();

            if (subject == null)
            {
                return null;
            }

            var dataToReturn = new
            {
                SubjectId = SubjectId,
                SubjectName = subject.SubjectName,
                StudentRegisteredSubject = subject.StudentRegisteredSubject.Select(s => new
                {
                    StudentId = s.Student.StudentId,
                    Username = s.Student.Person.Account.UserName,
                    StudentName = s.Student.Person.FullName,
                    PhoneNumber = s.Student.Person.PhoneNumber,
                    Address = s.Student.Person.Address,
                    Teacher = new
                    {
                        TeacherId = s.Teacher.TeacherId,
                        TeacherName = s.Teacher.Person.FullName
                    },
                    Classroom = new
                    {
                        ClassroomId = s.Classroom.ClassRoomId,
                        ClassroomName = s.Classroom.ClassroomName
                    },
                    Time = new
                    {
                        TimeId = s.Time.TimeId,
                        DayOfWeek = s.Time.DayOfWeek,
                        StartTime = s.Time.StartTime,
                        EndTime = s.Time.EndTime,
                    },

                    Mark1 = s.Mark1,
                    Mark2 = s.Mark2,
                    Mark3 = s.Mark3

                })
            };

            return dataToReturn;
        }

       

        public async Task<object> UpdateIsOpenAsync(OpenCloseSubject subjectDTO)
        {
            var isExistedSubject = await context.Subject
                .FirstOrDefaultAsync(s => s.SubjectId == subjectDTO.SubjectId);

            if (isExistedSubject == null)
            {
                return null;
            }

            if(subjectDTO.isOpen == true)
            {
                isExistedSubject.isOpen = true;
            }

            else isExistedSubject.isOpen = false;

            context.Subject.Update(isExistedSubject);

            await context.SaveChangesAsync();

            var dataToReturn = new
            {
                SubjectId = isExistedSubject.SubjectId,
                SubjectName = isExistedSubject.SubjectName,
                isOpen = isExistedSubject.isOpen == true ? "Đang mở" : "Đang đóng"
            };

            return dataToReturn;
        }

    }
}
