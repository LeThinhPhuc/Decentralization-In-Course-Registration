using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IClassroomService
    {
        Task<IEnumerable<object>> GetAllClassroomsAsync();

        Task<object> AddNewClassroomAsync(NewClassroomDTO newClassRoom);

        Task<object> RemoveClassroomAsync(string newClassroomId);

        Task<object> UpdateClassroomAsync(NewClassroomDTO newClassroom);
    }
}
