using System.Threading.Tasks;

namespace Lottery.Application.Abstract
{
    public interface ILoginService
    {
        Task<long> LogIn(string username, string password);
        Task<bool> LogInAsAdmin(string username, string password);
        Task<bool> Register(string username, string password);
    }
}
