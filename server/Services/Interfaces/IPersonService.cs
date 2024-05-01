using BMCSDL.DTOs;

namespace BMCSDL.Services.Interfaces
{
    public interface IPersonService
    {
        Task<object> UpdatePersonInformationAsync(UpdatePersonInfo updatePersonInfo);
    }
}
