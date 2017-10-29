using Lottery.WebApi.DTO;
using System.Threading.Tasks;

namespace Lottery.WebApi.IServices
{
    public interface IUserService
    {
        Task<bool> IsUserExists(UserDTO user);
        Task<bool> RegisterUserAndResponseResult(UserDTO user);
    }
}
