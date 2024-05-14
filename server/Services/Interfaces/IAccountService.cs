using BMCSDL.DTOs;
using BMCSDL.ReturnModels;

namespace BMCSDL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAllAccountsAsync();

        Task<UserDTO> LoginAsync(LoginDTO account);

        Task<UserRegisterDTO> RegisterAsync(UserRegisterDTO userRegisterDTO);

        Task<object> DeleteAccountAsync(string accountId);
    }
}
