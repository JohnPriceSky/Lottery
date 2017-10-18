using Lottery.Application.Services;
using Lottery.Console.ConsoleWindows;

namespace Lottery.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginService = new LoginService();

            var loginWindow = new LoginWindow(loginService);
            loginWindow.Print();
        }
    }
}
