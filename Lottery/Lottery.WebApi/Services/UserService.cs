using Lottery.WebApi.DTO;
using Lottery.WebApi.IServices;
using Lottery.WebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly LotteryEntities _lotteryEntities;

        public UserService(LotteryEntities lotteryEntities)
        {
            _lotteryEntities = lotteryEntities;
        }

        public async Task<IsLoggedInDTO> IsUserExists(UserDTO user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                var lotteryUser = await GetUserFromDB(user);

                if (lotteryUser != null)
                    return new IsLoggedInDTO { Id = lotteryUser.Id, IsLeggedIn = true };
            }

            return new IsLoggedInDTO { Id = int.MinValue, IsLeggedIn = false };
        }

        public async Task<bool> IsAdmin(UserDTO user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                var lotteryUser = await GetAdminFromDB(user);

                if (lotteryUser != null)
                    return true;
            }

            return false;
        }

        public async Task<bool> RegisterUserAndResponseResult(UserDTO user)
        {
            if (await IsUserAlreadyExist(user.UserName))
                return false;

            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                await RegisterUser(user);

                return true;
            }

            return false;
        }

        private async Task<User> GetUserFromDB(UserDTO user)
        {
            return _lotteryEntities.User.AsNoTracking()
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        }

        private async Task<Admin> GetAdminFromDB(UserDTO user)
        {
            return _lotteryEntities.Admin.AsNoTracking()
                .FirstOrDefault(a => a.UserName == user.UserName && a.Password == user.Password);
        }

        private async Task RegisterUser(UserDTO user)
        {
            var newUser = new User { UserName = user.UserName, Password = user.Password };

            _lotteryEntities.User.Add(newUser);
            await _lotteryEntities.SaveChangesAsync();
        }

        private async Task<bool> IsUserAlreadyExist(string userName)
        {
            var user = _lotteryEntities.User.AsNoTracking()
                .FirstOrDefault(u => u.UserName == userName);

            if (user != null)
                return true;

            return false;
        }
    }
}