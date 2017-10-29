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
        public async Task<bool> LoginIn([FromBody] UserDTO user)
        {
            if (user == null)
                return false;

            return await _loginService.IsUserExists(user);
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
