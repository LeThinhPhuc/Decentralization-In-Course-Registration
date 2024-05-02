using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface ITimeService
    {
        Task<IEnumerable<object>> GetAllTimeAsync();

        Task<object> GetTimeByIdAsync(string timeId);

        Task<object> AddTimeAsync(NewTimeDTO newTime);

        Task<object> UpdateTime(NewTimeDTO time);

        Task<object> DeleteTimeAsync(string timeId);
    }
}
