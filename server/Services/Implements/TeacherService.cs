using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

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


        public async Task<IEnumerable<TeacherAndTimeDTO>> GetAllTeachersAsync()
        {
            var teachers = await context.Teacher
                .Include(t => t.Person)
                .ThenInclude(p => p.Faculty)
                .Include(t => t.SubjectClass)
                .ThenInclude(s => s.Subject)
                .Include(t => t.SubjectClass)
                .ThenInclude(s => s.Classroom)
                .Include(t => t.SubjectClass)
                .ThenInclude(s => s.Time)

                .ToListAsync();


            IEnumerable<TeacherAndTimeDTO> dataToReturn = teachers.Select(t => new TeacherAndTimeDTO()
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
            }); ; ;
            return dataToReturn;

        }

        public async Task<SubjectClassDTO> AddTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO)
        {
            var isExistedTime = await context.SubjectClass
                .FirstOrDefaultAsync(sc => sc.SubjectId == teacherTimeDTO.SubjectId
                && sc.ClassroomId == teacherTimeDTO.ClassRoomId
                && sc.TimeId == teacherTimeDTO.TimeId
                && sc.TeacherId == teacherTimeDTO.TeacherId);

            if (isExistedTime != null)
            {
                return null;
            }

            var dataToReturn = mapper.Map<SubjectClassDTO>(teacherTimeDTO);

            return dataToReturn;

        }

        public async Task<SubjectClassDTO> RemoveTeacherTimeAsync(TeacherNewTimeDTO teacherTimeDTO)
        {
            var isExistedTime = await context.SubjectClass
               .FirstOrDefaultAsync(sc => sc.SubjectId == teacherTimeDTO.SubjectId
               && sc.ClassroomId == teacherTimeDTO.ClassRoomId
               && sc.TimeId == teacherTimeDTO.TimeId
               && sc.TeacherId == teacherTimeDTO.TeacherId);

            if (isExistedTime != null)
            {
                context.SubjectClass.Remove(isExistedTime);
                context.SaveChanges();
            }
            return null;
        }

    }
}
