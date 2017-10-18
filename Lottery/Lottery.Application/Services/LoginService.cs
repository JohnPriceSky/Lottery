using Lottery.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Application.Services
{
    public class LoginService : ILoginService
    {
        public bool LogIn(string username, string password)
        {
            return true;
        }
    }
}
