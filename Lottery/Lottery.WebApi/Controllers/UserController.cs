using Lottery.WebApi.DTO;
using Lottery.WebApi.IServices;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lottery.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _loginService;

        public UserController(IUserService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost, Route("login")]
        public async Task<IsLoggedInDTO> LoginIn([FromBody] UserDTO user)
        {
            if (user == null)
                return new IsLoggedInDTO { Id = int.MinValue, IsLoggedIn = false };

            return await _loginService.IsUserExists(user);
        }

        [HttpPost, Route("loginToAdmin")]
        public async Task<bool> LoginInToAdmin([FromBody] UserDTO user)
        {
            if (user == null)
                return false;

            return await _loginService.IsAdmin(user);
        }

        [HttpPost, Route("register")]
        public async Task<bool> RegisterUser([FromBody] UserDTO user)
        {
            if (user == null)
                return false;

            return await _loginService.RegisterUserAndResponseResult(user);
        }
    }
}
