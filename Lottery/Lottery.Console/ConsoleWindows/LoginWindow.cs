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
            string username = "", password = "";
            bool firstTime = true;
            while (username.Trim().Equals("") || password.Trim().Equals(""))
            {
                DrawMenu();
                if (!firstTime)
                {
                    System.Console.SetCursorPosition(40, 12);
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write("Write your username and/or password");
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
                firstTime = false;
                System.Console.SetCursorPosition(40, 15);
                username = System.Console.ReadLine();
                System.Console.SetCursorPosition(65, 15);
                password = System.Console.ReadLine();
            }
            if (LogInOrRegister())
            {
                if (_loginService.LogIn(username, password))
                {
                    var dashboardWindow = new DashboardWindow(username);
                    dashboardWindow.Print();
                }
            }
            //else
            //TODO: Register(username, password);

        }

        private void DrawMenu()
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Blue;
            System.Console.SetCursorPosition(6, 1);
            System.Console.Write("WELCOME TO LOTTERY!");

            System.Console.ForegroundColor = ConsoleColor.Black;
            System.Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.SetCursorPosition(40, 14);
            System.Console.Write("Username:");
            System.Console.SetCursorPosition(40, 15);
            System.Console.Write("______________");
            System.Console.SetCursorPosition(65, 14);
            System.Console.Write("Password:");
            System.Console.SetCursorPosition(65, 15);
            System.Console.Write("______________");
            System.Console.SetCursorPosition(45, 25);
            System.Console.Write("LOGIN");
            System.Console.SetCursorPosition(65, 25);
            System.Console.Write("REGISTER");
        }

        private static bool LogInOrRegister()
        {
            System.Console.CursorVisible = false;
            bool isLogin = true;
            while (true)
            {
                System.Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.ForegroundColor = ConsoleColor.Black;
                if (isLogin)
                {
                    System.Console.SetCursorPosition(45, 25);
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write("LOGIN");
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.SetCursorPosition(65, 25);
                    System.Console.Write("REGISTER");
                }
                else
                {
                    System.Console.SetCursorPosition(45, 25);
                    System.Console.Write("LOGIN");
                    System.Console.SetCursorPosition(65, 25);
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write("REGISTER");
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
                ConsoleKeyInfo cki = System.Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        isLogin = true;
                        break;
                    case ConsoleKey.RightArrow:
                        isLogin = false;
                        break;
                    case ConsoleKey.Enter:
                        return isLogin;
                    default:
                        break;
                }
            }
        }
    }
}
