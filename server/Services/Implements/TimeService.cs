using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace BMCSDL.Services.Implements
{
    public class TimeService : ITimeService
    {
        private CourseRegistraionManagementContext context;

        public TimeService(CourseRegistraionManagementContext context)
        {
            this.context = context;
        }

        public static TimeSpan ParseTimeStringToTimeSpan(string timeString)
        {
            TimeSpan timeSpan;
            if (TimeSpan.TryParse(timeString, out timeSpan))
            {
                return timeSpan;
            }
            else
            {
                throw new ArgumentException("Invalid time format");
            }
        }
        public async Task<object> AddTimeAsync(NewTimeDTO newTime)
        {

            //kiểm tra thời gian có bị chống chéo không
            var times = await context.Time.
                Where(t => t.DayOfWeek == newTime.DayOfWeek).ToListAsync();

            var newStartTime = ParseTimeStringToTimeSpan(newTime.StartTime);
            var newEndTime = ParseTimeStringToTimeSpan(newTime.EndTime);

            foreach (var t in times)
            {
                if(t.StartTime <= newStartTime && newEndTime <= t.EndTime || newStartTime <= t.StartTime && t.StartTime <= newEndTime)
                {
                    return null;
                }
            }

            string timeId = Guid.NewGuid().ToString();

            Time time = new Time()
            {
                TimeId = timeId,
                TimeName = newTime.TimeName,
                DayOfWeek = DayOfWeek.Sunday,   
                StartTime = newStartTime,
                EndTime = newEndTime,  
            };

            context.Time.Add(time);
            await context.SaveChangesAsync();

            return newTime;
        }


        public async Task<object> DeleteTimeAsync(string timeId)
        {
            var time = await context.Time.FirstOrDefaultAsync(t => t.TimeId == timeId);

            if (time == null)
            {
                return null;
            }

            context.Time.Remove(time);
            context.SaveChanges();

            return new
            {
                TimeId = time.TimeId,
                TimeName = time.TimeName,
                StartTime = time.StartTime,
                EndTIme = time.EndTime,
                DayOfWeek = time.DayOfWeek,
            };
        }

        public async Task<IEnumerable<object>> GetAllTimeAsync()
        {
            var time = await context.Time.ToListAsync();

            if(time.Count == 0)
            {
                return null;
            }

            var dataToReturn = time.Select(t => new
            {
                TimeId = t.TimeId,
                TimeName = t.TimeName,
                StartTime = t.StartTime,
                EndTIme = t.EndTime,
                DayOfWeek = t.DayOfWeek,
            });

            return dataToReturn;
        }

        public async Task<object> GetTimeByIdAsync(string timeId)
        {
            var time = await context.Time.FirstOrDefaultAsync(t => t.TimeId == timeId);

            if(time == null)
            {
                return null;
            }

            return new
            {
                TimeId = time.TimeId,
                TimeName = time.TimeName,
                StartTime = time.StartTime,
                EndTIme = time.EndTime,
                DayOfWeek = time.DayOfWeek,
            };

        }

        public Task<object> UpdateTime(NewTimeDTO time)
        {
            throw new NotImplementedException();
        }
    }
}
