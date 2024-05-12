using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<object> RegisterSubjectAsync(RegistrationSubjectFormDTO regisForm)
        {
            //kiểm tra môn học có được mở không
            var isOpen = await context.Subject
                .FirstOrDefaultAsync(s => s.SubjectId == regisForm.SubjectId
                && s.isOpen == true);

            //nếu bằng null thì môn học không được mở hoặc không có môn học
            if (isOpen == null)
            {
                return null;
            }



            //check xem sinh viên có đăng kí môn học chưa, nếu có rồi thì không cho đăng kí nữa
            var isRegisteredSubject = await context.StudentRegisteredSubject
                .FirstOrDefaultAsync(e => e.StudentId == regisForm.StudentId
                && e.SubjectId == regisForm.SubjectId);

            if (isRegisteredSubject != null)
            {
                return null;
            }

            //check xem có lịc học trong subjectClass không
            var subjectClass = await context.SubjectClass.FirstOrDefaultAsync(s =>
            s.SubjectId == regisForm.SubjectId
            && s.ClassroomId == regisForm.ClassroomId
            && s.TimeId == regisForm.TimeId
            && s.TeacherId == regisForm.TeacherId);

            if (subjectClass == null)
            {
                return null;
            }


            await using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                //kiểm tra còn slot không
                var room = await context.Classroom
                    .FirstOrDefaultAsync(c => c.ClassRoomId == regisForm.ClassroomId);

                if (room != null && room.CurrentQuantity < room.MaxQuantity)
                {
                    room.CurrentQuantity++;
                    context.Classroom.Update(room);
                    var newRegistrationSubject = new StudentRegisteredSubject()
                    {
                        StudentId = regisForm.StudentId,
                        SubjectId = regisForm.SubjectId,
                        ClassroomId = regisForm.ClassroomId,
                        TeacherId = regisForm.TeacherId,
                        TimeId = regisForm.TimeId,
                        Mark1 = 0,
                        Mark2 = 0,
                        Mark3 = 0,
                        RegisterDate = DateTime.Now,
                    };

                    context.StudentRegisteredSubject.Add(newRegistrationSubject);
                    context.SaveChanges();
                    var subject = await context.Subject.FirstOrDefaultAsync(s => s.SubjectId == regisForm.SubjectId);
                    await transaction.CommitAsync();
                    return mapper.Map<SubjectDTO>(subject);
                }
                else
                {
                    return null;
                }
            }

            catch
            {
                await transaction.RollbackAsync();
                return null;
            }


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
            var student = await context.Student.Where(s => s.StudentId == studentId)
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
                        subjectName = s.Subject.SubjectName
                    },
                    classroom = new
                    {
                        classRoomId = s.Classroom.ClassRoomId,
                        classroomName = s.Classroom.ClassroomName
                    },

                    date = new
                    {
                        startDay = s.Subject.StartDay,
                        endDay = s.Subject.EndDay,  
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
                    },
                    marks = new
                    {
                        mark1 = s.Mark1,
                        mark2 = s.Mark2,
                        mark3 = s.Mark3,
                    }
                })

            };
            return studentToReturn;
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

            if (student == null)
            {
                return null;
            }

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

        public async Task<object> UpdateStudentByAsync(UpdateStudentInfo studentInfo)
        {
            if (!String.IsNullOrEmpty(studentInfo.PersonInfo.FacultyId))
            {
                var isExistedFaculty = await context.Faculty
                    .FirstOrDefaultAsync(f => f.FacultyId == studentInfo.PersonInfo.FacultyId);

                if (isExistedFaculty == null)
                {
                    return null;
                }
            }


            var isExistedStudent = await context.Student
                .FirstOrDefaultAsync(s => s.StudentId == studentInfo.PersonInfo.PersonId);

            if (isExistedStudent == null)
            {
                return null;
            }

            else
            {
                var student = await context.Student.Include(s => s.Person)
                .FirstOrDefaultAsync(s => s.StudentId == studentInfo.PersonInfo.PersonId);

                if (!String.IsNullOrEmpty(studentInfo.PersonInfo.FullName))
                {
                    student.Person.FullName = studentInfo.PersonInfo.FullName;
                }

                if (!string.IsNullOrEmpty(studentInfo.PersonInfo.Gender))
                {
                    student.Person.Gender = studentInfo.PersonInfo.Gender;
                }

                if (!string.IsNullOrEmpty(studentInfo.PersonInfo.PhoneNumber))
                {
                    student.Person.PhoneNumber = studentInfo.PersonInfo.PhoneNumber;
                }

                if (studentInfo.PersonInfo.DateOfBirth != default(DateTime))
                {
                    student.Person.DateOfBirth = studentInfo.PersonInfo.DateOfBirth;
                }

                if (!String.IsNullOrEmpty(studentInfo.PersonInfo.Address))
                {
                    student.Person.Address = studentInfo.PersonInfo.Address;
                }

                if (!String.IsNullOrEmpty(studentInfo.PersonInfo.FacultyId))
                {
                    student.Person.FacultyId = studentInfo.PersonInfo.FacultyId;
                }

                context.Update(student);

                context.SaveChanges();

                return studentInfo;
            }

            return null;
        }
    }
}
