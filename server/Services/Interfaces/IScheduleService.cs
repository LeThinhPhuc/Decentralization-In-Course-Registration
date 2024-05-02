using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<object>> GetAllScheduleAsync();
        Task<IEnumerable<object>> GetAllScheduleWithTeacherAsync();

        Task<object> AddNewScheduleAsync(NewScheduleDTO newSchedule);
        Task<object> RemoveScheduleAsync(NewScheduleDTO deleteSchedule);
        Task<object> UpdateScheduleAsync(ScheduleDTO newInfoSchedule);
    }
}
