using Lottery.Application.Abstract;
using Lottery.Console.Abstract;
using System;

namespace Lottery.Console.ConsoleWindows
{
    class LoginWindow : IConsoleWindow
    {
        private readonly ILoginService _loginService;

        public LoginWindow(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public void Print()
        {
            System.Console.WriteLine("xd");
            System.Console.WriteLine(_loginService.LogIn("xd", "dx"));
        }
    }
}
