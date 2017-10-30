using Lottery.WebApi.DTO;
using System.Threading.Tasks;

namespace Lottery.WebApi.IServices
{
    public interface IUserService
    {
        Task<IsLoggedInDTO> IsUserExists(UserDTO user);
        Task<bool> IsAdmin(UserDTO user);
        Task<bool> RegisterUserAndResponseResult(UserDTO user);
    }
}
