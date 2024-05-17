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

            //check xem có lịch học trong subjectClass không
            var subjectClass = await context.SubjectClass.Where(s =>
            s.SubjectId == regisForm.SubjectId
            && s.ClassroomId == regisForm.ClassroomId
            && s.TimeId == regisForm.TimeId
            && s.TeacherId == regisForm.TeacherId)
                .Include(s => s.Classroom)
                .Include(s => s.Subject)
                .Include(s => s.Time)
                .Include(s => s.Teacher)
                .ThenInclude(t => t.Person)
                .FirstOrDefaultAsync();

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



                if (room != null && subjectClass.CurrentQuantity < room.MaxQuantity)
                {
                    subjectClass.CurrentQuantity++;
                    context.SubjectClass.Update(subjectClass);
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
                    await transaction.CommitAsync();

                    return new
                    {
                        subject = new
                        {
                            subjectId = subjectClass.Subject.SubjectId,
                            subjectName = subjectClass.Subject.SubjectName
                        },
                        time = new
                        {
                            time = subjectClass.Time.TimeId,
                            StartTime = subjectClass.Time.StartTime,
                            EndTime = subjectClass.Time.EndTime,
                        },
                        teacher = new
                        {
                            teacherId = subjectClass.Teacher.TeacherId,
                            teacherName = subjectClass.Teacher.Person.FullName
                        },
                        classroom = new
                        {
                            ClassroomId = subjectClass.Classroom.ClassRoomId,
                            ClassroomName = subjectClass.Classroom.ClassroomName,
                            MaxQuantity = subjectClass.Classroom.MaxQuantity,
                        },
                        CurrentSlot = subjectClass.CurrentQuantity
                    };
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

        public async Task<object> RemoveRegisteredSubjectAsync(RegistrationSubjectFormDTO regisForm)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Kiểm tra học sinh có học môn đó không
                    var registeredSubject = await context
                        .StudentRegisteredSubject
                        .Where(s => s.StudentId == regisForm.StudentId && s.SubjectId == regisForm.SubjectId)
                        .FirstOrDefaultAsync();

                    if (registeredSubject == null)
                    {
                        return null;
                    }

                    // Tiếp theo, update schedule học phần đó trừ 1 slot
                    var subjectClass = await context.SubjectClass.Where(s =>
            s.SubjectId == regisForm.SubjectId
            && s.ClassroomId == regisForm.ClassroomId
            && s.TimeId == regisForm.TimeId
            && s.TeacherId == regisForm.TeacherId)
                .Include(s => s.Classroom)
                .Include(s => s.Subject)
                .Include(s => s.Time)
                .Include(s => s.Teacher)
                .ThenInclude(t => t.Person)
                .FirstOrDefaultAsync();

                    if (subjectClass == null)
                    {
                        return null;
                    }

                    // Giảm số lượng hiện tại
                    subjectClass.CurrentQuantity--;
                    context.SubjectClass.Update(subjectClass);

                    // Xóa đăng ký học phần của học sinh
                    context.StudentRegisteredSubject.Remove(registeredSubject);

                    // Lưu thay đổi
                    await context.SaveChangesAsync();

                    // Commit transaction
                    await transaction.CommitAsync();



                    return new
                    {
                        subject = new
                        {
                            subjectId = subjectClass.Subject.SubjectId,
                            subjectName = subjectClass.Subject.SubjectName
                        },
                        time = new
                        {
                            time = subjectClass.Time.TimeId,
                            StartTime = subjectClass.Time.StartTime,
                            EndTime = subjectClass.Time.EndTime,
                        },
                        teacher = new
                        {
                            teacherId = subjectClass.Teacher.TeacherId,
                            teacherName = subjectClass.Teacher.Person.FullName
                        },
                        classroom = new
                        {
                            ClassroomId = subjectClass.Classroom.ClassRoomId,
                            ClassroomName = subjectClass.Classroom.ClassroomName,
                            MaxQuantity = subjectClass.Classroom.MaxQuantity,
                        },
                        CurrentQuantity = subjectClass.CurrentQuantity
                    };
                }
                catch
                {
                    // Rollback transaction nếu có lỗi xảy ra
                    await transaction.RollbackAsync();
                    throw;
                }
            }
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

        public async Task<object> UpdateMarkAsync(UpdateMark newMark)
        {
            //kiểm tra có student không
            if(await context.Student.FirstOrDefaultAsync(s => s.StudentId == newMark.StudentId) == null)
            {
                return 1;
            }
            //kiểm tra có subject không không

            if (await context.Subject.FirstOrDefaultAsync(s => s.SubjectId == newMark.SubjectId) == null)
            {
                return 2;
            }

            //kiểm tra học sinh có học môn đó không
            var studentSubject = await context
                .StudentRegisteredSubject
                .Where(s =>
                                        s.StudentId == newMark.StudentId && s.SubjectId == newMark.SubjectId)
                .Include (s => s.Subject)
                .Include(s => s.Student)
                .ThenInclude(s => s.Person)
                .FirstOrDefaultAsync();
            if (studentSubject == null)
            {
                return 3;
            }

            if(!String.IsNullOrEmpty(newMark.Mark1))
            {
                studentSubject.Mark1 = float.Parse(newMark.Mark1);
            }

            if (!String.IsNullOrEmpty(newMark.Mark2))
            {
                studentSubject.Mark2 = float.Parse(newMark.Mark2);
            }

            if (!String.IsNullOrEmpty(newMark.Mark3))
            {
                studentSubject.Mark3 = float.Parse(newMark.Mark3);
            }

            context.StudentRegisteredSubject.Update(studentSubject);
            context.SaveChanges();

            return new
            {
                Student = new
                {
                    StudentId = newMark.StudentId,
                    StudentName = studentSubject.Student.Person.FullName
                },
                Subject = new
                {
                    SubjectId = studentSubject.Subject.SubjectId,
                    SubjectName = studentSubject.Subject.SubjectName
                },
                Mark1 = studentSubject.Mark1,
                Mark2 = studentSubject.Mark2,
                Mark3 = studentSubject.Mark3,
            };

            }
    }
}
