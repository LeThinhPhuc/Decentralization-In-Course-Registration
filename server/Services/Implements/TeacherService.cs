using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;

namespace BMCSDL.Services.Implements
{
    public class TeacherService : ITeacherService
    {
        private CourseRegistraionManagementContext context;
        private readonly IMapper mapper;

        public TeacherService(CourseRegistraionManagementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<object>> GetAllTeachersAsync()
        {
            var teachers = await context.Teacher
                .Include(t => t.Person)
                .ThenInclude(p => p.Faculty)
                //.Include(t => t.SubjectClass)
                //.ThenInclude(s => s.Subject)
                //.Include(t => t.SubjectClass)
                //.ThenInclude(s => s.Classroom)
                //.Include(t => t.SubjectClass)
                //.ThenInclude(s => s.Time)
                .ToListAsync();

            var dataToReturn = teachers.Select(teacher => new
            {
                TeacherId = teacher.TeacherId,
                TeacherName = teacher.Person.FullName,
                TeacherInfo = new
                {
                    FullName = teacher.Person.FullName,
                    Gender = teacher.Person.Gender,
                    PhoneNumber = teacher.Person.PhoneNumber,
                    DateOfBirth = teacher.Person.DateOfBirth,
                    Address = teacher.Person.Address,
                },
                Faculty = new
                {
                    FacultyId = teacher.Person.Faculty.FacultyId,
                    FacultyName = teacher.Person.Faculty.FacultyName
                }
            });

            return dataToReturn;

        }

        public async Task<object> AddTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO)
        {

            //check có bị trùng time không
            //hiện tại do Time không bị đề lấn nhau nên giáo viên không bị trừng giờ

            var isExistedTimeAndTeacher = await context.SubjectClass
                .FirstOrDefaultAsync(sc => sc.TimeId == teacherTimeDTO.TimeId
                && sc.TeacherId == teacherTimeDTO.TeacherId);


            if (isExistedTimeAndTeacher != null)
            {
                return null;
            }

            //kiểm tra có trừng phòng và thời gian không
            var isExistedTimeAndClassroom = await context.SubjectClass
                .FirstOrDefaultAsync(sc => sc.ClassroomId == teacherTimeDTO.ClassRoomId 
                && sc.TimeId == teacherTimeDTO.TimeId);

            var newTime = new SubjectClass()
            {
                SubjectId = teacherTimeDTO.SubjectId,
                ClassroomId = teacherTimeDTO.ClassRoomId,
                TimeId = teacherTimeDTO.TimeId,
                TeacherId  = teacherTimeDTO.TeacherId,  
            };

            context.SubjectClass.Add(newTime);
            await context.SaveChangesAsync();

            var time = context.SubjectClass
                .Where(sc => 
                sc.SubjectId == teacherTimeDTO.SubjectId 
                && sc.ClassroomId == teacherTimeDTO.ClassRoomId
                && sc.TimeId == teacherTimeDTO.TimeId
                && sc.TeacherId == teacherTimeDTO.TeacherId)
                .Include(sc => sc.Subject)
                .Include (sc => sc.Classroom)   
                .Include(sc => sc.Time)
                .Include(sc => sc.Teacher)
                .ThenInclude(t => t.Person)
                .FirstOrDefault();

            var dataToReturn = new
            {
                TeacherId = time.Teacher.TeacherId,
                TeacherName = time.Teacher.Person.FullName,
                newSchedule = new
                {
                    subject  = new
                    {
                        subjecId = time.Subject.SubjectId,
                        subjectName = time.Subject.SubjectName,
                    },
                    classroom = new
                    {
                        classroomId = time.Classroom.ClassRoomId,
                        classroomName = time.Classroom.ClassroomName
                    },
                    time = new
                    {
                        timeId = time.Time.TimeId,
                        timeName = time.Time.TimeName,
                        DayOfWeek = time.Time.DayOfWeek,
                        StartTime = time.Time.StartTime,
                        EndTime = time.Time.EndTime,    
                    }
                }
            };
            return dataToReturn;

        }

        public async Task<object> RemoveTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO)
        {
            var isExistedTime = await context.SubjectClass
                .Include(sc => sc.Subject)
                .Include(sc => sc.Classroom)
                .Include(sc => sc.Time) 
                .Include(sc => sc.Teacher)
                .ThenInclude(sc => sc.Person)
               .FirstOrDefaultAsync(sc => sc.SubjectId == teacherTimeDTO.SubjectId
               && sc.ClassroomId == teacherTimeDTO.ClassRoomId
               && sc.TimeId == teacherTimeDTO.TimeId
               && sc.TeacherId == teacherTimeDTO.TeacherId);

            if (isExistedTime != null)
            {
                context.SubjectClass.Remove(isExistedTime);
                context.SaveChanges();


                var dataToReturn = new
                {
                    Teacher = new
                    {
                        TeacherId = isExistedTime.Teacher.TeacherId,
                        TeacherName = isExistedTime.Teacher.Person.FullName
                    },
                    Subject = new
                    {
                        Subjectid = isExistedTime.Subject.SubjectId,
                        SubjectName =isExistedTime.Subject.SubjectName,
                    },
                    Classroom = new
                    {
                        Classroomid = isExistedTime.Classroom.ClassRoomId,
                        ClassroomName = isExistedTime.Classroom.ClassroomName
                    },
                    Time = new
                    {
                        TimeId = isExistedTime.Time.TimeId,
                        TimeName = isExistedTime.Time.TimeName,
                        StartTime = isExistedTime.Time.StartTime,
                        EndTime = isExistedTime.Time.EndTime,   
                    }
                };
                return dataToReturn;
            }
            return null;
        }

        public async Task<object> GetTeacherByIdAsync(string teacherId)
        {
            var teacher = await context.Teacher
                .Include(t => t.Person)
                .ThenInclude(p => p.Faculty).FirstOrDefaultAsync();

            if (teacher == null)
            {
                return null;
            }


            return new
            {
                TeacherId = teacher.TeacherId,
                TeacherName = teacher.Person.FullName,
                TeacherInfo = new
                {
                    FullName = teacher.Person.FullName,
                    Gender = teacher.Person.Gender,
                    PhoneNumber = teacher.Person.PhoneNumber,
                    DateOfBirth = teacher.Person.DateOfBirth,
                    Address = teacher.Person.Address,
                },
                Faculty = new
                {
                    FacultyId = teacher.Person.Faculty.FacultyId,
                    FacultyName = teacher.Person.Faculty.FacultyName
                }
            };
        }

        public async Task<object> GetTeacherTeachingSchelduleAsync(string teacherId)
        {
            var t = await context.Teacher.Where(t => t.TeacherId == teacherId)
               .Include(t => t.Person)
               .ThenInclude(p => p.Faculty)
               .Include(t => t.SubjectClass)
               .ThenInclude(s => s.Subject)
               .Include(t => t.SubjectClass)
               .ThenInclude(s => s.Classroom)
               .Include(t => t.SubjectClass)
               .ThenInclude(s => s.Time).FirstOrDefaultAsync();

            if (t == null)
            {
                return null;
            }

            var dataToReturn = new
            {
                TeacherId = t.TeacherId,
                Person = new PersonDTO()
                {
                    FullName = t.Person.FullName,
                    Gender = t.Person.Gender,
                    PhoneNumber = t.Person.PhoneNumber,
                    DateOfBirth = t.Person.DateOfBirth,
                    Address = t.Person.Address,
                    FacultyId = t.Person.FacultyId
                },
                RoomTimeSubject = t.SubjectClass.Select(s => new RoomTimeSubject()
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
                        EndTime = s.Time.EndTime
                    },
                    Subject = new SubjectDTO2()
                    {
                        SubjectId = s.Subject.SubjectId,
                        SubjectName = s.Subject.SubjectName,
                    }
                }).ToList()
            };

            return dataToReturn;
        }
    }
}
