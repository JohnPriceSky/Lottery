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
            //DrawBorder();
            DrawMenu();
            string username = System.Console.ReadLine();
            System.Console.SetCursorPosition(55, 15);
            string password = System.Console.ReadLine();

            if (LogInOrRegister())
                _loginService.LogIn(username, password);
            //else
                //TODO: Register(username, password);

        }

        private static void DrawMenu()
        {
            System.Console.SetCursorPosition(5, 4);
            System.Console.Write("Welcome to lottery!");
            System.Console.SetCursorPosition(20, 14);
            System.Console.Write("Username:");
            System.Console.SetCursorPosition(20, 15);
            System.Console.Write("______________");
            System.Console.SetCursorPosition(55, 14);
            System.Console.Write("Password:");
            System.Console.SetCursorPosition(55, 15);
            System.Console.Write("______________");
            System.Console.SetCursorPosition(80, 25);
            System.Console.Write("LOGIN");
            System.Console.SetCursorPosition(100, 25);
            System.Console.Write("REGISTER");

            System.Console.SetCursorPosition(20, 15);
        }

        private static bool LogInOrRegister()
        {
            System.Console.CursorVisible = false;
            bool isLogin = true;
            while (true)
            {
                if (isLogin)
                {
                    System.Console.SetCursorPosition(80, 25);
                    System.Console.BackgroundColor = ConsoleColor.White;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.Write("LOGIN");
                    System.Console.ResetColor();
                    System.Console.SetCursorPosition(100, 25);
                    System.Console.Write("REGISTER");
                }
                else
                {
                    System.Console.SetCursorPosition(80, 25);
                    System.Console.Write("LOGIN");
                    System.Console.SetCursorPosition(100, 25);
                    System.Console.BackgroundColor = ConsoleColor.White;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.Write("REGISTER");
                    System.Console.ResetColor();
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
