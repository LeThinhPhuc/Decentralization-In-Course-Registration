using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BMCSDL.Services.Implements
{
    public class ScheduleService : IScheduleService
    {
        private  CourseRegistraionManagementContext context;

        public ScheduleService(CourseRegistraionManagementContext context)
        {
            this.context = context;
        }


        public async Task<object> AddNewScheduleAsync(NewScheduleDTO newSchedule)
        {
            //check có bị trùng time không
            //hiện tại do Time không bị đề lấn nhau nên giáo viên không bị trừng giờ


            var isExistedTimeAndTeacher = await context.SubjectClass
                .FirstOrDefaultAsync(sc => sc.TimeId == newSchedule.TimeId
                && sc.TeacherId == newSchedule.TeacherId);


            if (isExistedTimeAndTeacher != null)
            {
                return null;
            }

            //kiểm tra xe môn học có mở không 
            var isOpenSubject = await context.Subject.FirstOrDefaultAsync(s => s.SubjectId == newSchedule.SubjectId && s.isOpen == true);

            if(isOpenSubject == null)
            {
                return null;
            }


            //kiểm tra có trừng phòng và thời gian không
            var isExistedTimeAndClassroom = await context.SubjectClass
                .FirstOrDefaultAsync(sc => sc.ClassroomId == newSchedule.ClassRoomId
                && sc.TimeId == newSchedule.TimeId);

            var newTime = new SubjectClass()
            {
                SubjectId = newSchedule.SubjectId,
                ClassroomId = newSchedule.ClassRoomId,
                TimeId = newSchedule.TimeId,
                TeacherId = newSchedule.TeacherId,
            };

            context.SubjectClass.Add(newTime);
            await context.SaveChangesAsync();

            var time = context.SubjectClass
                .Where(sc =>
                sc.SubjectId == newSchedule.SubjectId
                && sc.ClassroomId == newSchedule.ClassRoomId
                && sc.TimeId == newSchedule.TimeId
                && sc.TeacherId == newSchedule.TeacherId)
                .Include(sc => sc.Subject)
                .Include(sc => sc.Classroom)
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
                    subject = new
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



        public async Task<IEnumerable<object>> GetAllScheduleAsync()
        {
            var schedules = await context.SubjectClass
                .Include(s => s.Subject)
                .Include(s => s.Time)
                .Include(s => s.Classroom)
                .Include(s => s.Teacher)
                .ThenInclude(t => t.Person)
                .ToListAsync();

            if(schedules.Count() == 0)
            {
                return null;
            }

            var schedulesToReturn = schedules.Select(s => new
            {
                Subject = new
                {
                    SubjectId = s.Subject.SubjectId,
                    SubjectName = s.Subject.SubjectName,
                    Credits = s.Subject.Credits,
                    StartDay = s.Subject.StartDay,
                    EndDay = s.Subject.EndDay,
                },
                Classroom = new
                {
                    ClassroomId = s.Classroom.ClassRoomId,
                    ClassroomName = s.Classroom.ClassroomName
                },
                Timed = new
                {
                    TimeId = s.Time.TimeId,
                    TimeName = s.Time.TimeName,
                    DayOfWeek = s.Time.DayOfWeek,
                    StartTime = s.Time.StartTime,
                    EndTime = s.Time.EndTime,
                },
                Teacher = new
                {
                    TeacherId = s.Teacher.TeacherId,
                    TeacherName = s.Teacher.Person.FullName
                }
            });

            return schedulesToReturn;
        }

        public Task<IEnumerable<object>> GetAllScheduleWithTeacherAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> RemoveScheduleAsync(ScheduleDTO newSchedule)
        {
            throw new NotImplementedException();
        }

        public async Task<object> RemoveScheduleAsync(NewScheduleDTO deleteSchedule)
        {
            var schedule = await context.SubjectClass
                .Where(s => 
                s.SubjectId == deleteSchedule.SubjectId
                && s.ClassroomId == deleteSchedule.ClassRoomId
                && s.TimeId == deleteSchedule.TimeId
                && s.TeacherId == deleteSchedule.TeacherId)
                .Include(s => s.Subject)
                .Include(s => s.Classroom)
                .Include(s => s.Time)
                .Include(s => s.Teacher)
                .ThenInclude(t => t.Person)
                .FirstOrDefaultAsync();


            if(schedule == null)
            {
                return null;
            }

            //khi xóa thời schedule này thì student này đăng kí lịch này sẽ xóa theo
            var registerdSubject = await context.StudentRegisteredSubject.Where(s =>
                s.SubjectId == deleteSchedule.SubjectId
                && s.ClassroomId == deleteSchedule.ClassRoomId
                && s.TimeId == deleteSchedule.TimeId
                && s.TeacherId == deleteSchedule.TeacherId).ToListAsync();

            context.StudentRegisteredSubject.RemoveRange(registerdSubject);

            context.SubjectClass.Remove(schedule);

            context.SaveChanges();

            var dataToReturn = new
            {
                Subject = new
                {
                    SubjectId = schedule.Subject.SubjectId,
                    SubjectName = schedule.Subject.SubjectName,
                },
                Classroom = new
                {
                    ClassroomId = schedule.Classroom.ClassRoomId,
                    ClassroomName = schedule.Classroom.ClassroomName,   
                },
                Time = new
                {
                    TimeId = schedule.Time.TimeId,
                    DayOfWeek = schedule.Time.DayOfWeek,
                    StartTime = schedule.Time.StartTime,
                    EndTime = schedule.Time.EndTime,
                },
                Teacher = new
                {
                    TeacherId = schedule.Teacher.TeacherId,
                    TeacherName = schedule.Teacher.Person.FullName
                }
            };

            return dataToReturn;
        }


        public Task<object> UpdateScheduleAsync(ScheduleDTO newInfoSchedule)
        {
            throw new NotImplementedException();
        }

        
    }
}
