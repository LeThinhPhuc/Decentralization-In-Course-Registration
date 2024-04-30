using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;

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

            //check xem sinh viên có đăng kí môn học chưa, nếu có rồi thì không cho đăng kí nữa
            var isRegisteredSubject = await context.StudentRegisteredSubject
                .FirstOrDefaultAsync(e => e.StudentId == regisForm.StudentId
                && e.SubjectId == regisForm.SubjectId);

            if(isRegisteredSubject != null) 
            {
                return null;
            }


            //cái này không cần cũng được
            var isRegisteredSubject2 = await context.StudentRegisteredSubject
                .FirstOrDefaultAsync(e => e.StudentId == regisForm.StudentId 
                && e.SubjectId == regisForm.SubjectId
                && e.ClassroomId == regisForm.ClassroomId
                && e.TeacherId == regisForm.TeacherId
                && e.TimeId == regisForm.TimeId);

            if (isRegisteredSubject2 != null)
            {
                return null;
            }

            var newRegistrationSubject = new StudentRegisteredSubject()
            {
                StudentId = regisForm.StudentId,
                SubjectId = regisForm.SubjectId,
                ClassroomId = regisForm.ClassroomId,
                TeacherId = regisForm.TeacherId,
                TimeId = regisForm.TimeId,
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

      

        public async Task<object> GetRegisteredSubjectsAsync(string studentId)
        {
            var student = await context.Student
                .Include(s => s.Person)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Subject)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Classroom)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(t => t.Person)
                .Include(s => s.StudentRegisteredSubject)
                .ThenInclude(s => s.Time).FirstOrDefaultAsync();

            var studentToReturn = new
            {
                StudentId = student.StudentId,
                StudentName = student.Person.FullName,
                registeredSubjects = student.StudentRegisteredSubject.Select(s => new
                {
                    subject = new 
                    {
                        subjectId = s.Subject.SubjectId,
                        subject = s.Subject.SubjectName
                    },
                    classroom = new
                    {
                        classRoomId = s.Classroom.ClassRoomId,
                        classroomName = s.Classroom.ClassroomName
                    },
                    time = new
                    {
                        timeId = s.Time.TimeId,
                        dayOfWeek = s.Time.DayOfWeek,
                        startTime = s.Time.StartTime,
                        endTime = s.Time.EndTime,   
                    },
                    teacher = new
                    {
                        teacherId = s.Teacher.TeacherId,
                        teacherName = s.Teacher.Person.FullName,
                    }
                })
            };
            return studentToReturn ;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var students = await context.Student
                .Include(s => s.Person)
                .ThenInclude(p => p.Faculty)
                .ToListAsync();


            return mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<object> GetStudentByIdAsync(string studentId)
        {
            var student = await context.Student
                .Include(s => s.Person)
                .ThenInclude(p => p.Faculty)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);


            var studentToReturn = new
            {
                studentId = student.StudentId,
                studentInformation = new
                {
                    fullName = student.Person.FullName,
                    gender = student.Person.Gender,
                    phoneNumber = student.Person.PhoneNumber,
                    dateOfBirth = student.Person.DateOfBirth,
                    address = student.Person.Address,   
                },
                faculty = new
                {
                    facultyId = student.Person.FacultyId,
                    facultyName = student.Person.Faculty.FacultyName
                }
            };
            return studentToReturn;


        }


    }
}
