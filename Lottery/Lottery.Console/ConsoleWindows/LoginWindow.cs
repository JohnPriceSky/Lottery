using Lottery.Application.Abstract;
using Lottery.Application.Services;
using Lottery.Console.Abstract;
using System;

namespace Lottery.Console.ConsoleWindows
{
    class LoginWindow : ConsoleWindow, IConsoleWindow
    {
        private readonly ILoginService _loginService;

        public LoginWindow(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public void Print()
        {
            while (true)
            {
                ClearHeader();
                ClearContent();
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
                var decision = LogInOrRegister();
                if (decision == 0)
                {
                    if (_loginService.LogIn(username, password).Result)
                    {
                        var lotteryService = new LotteryService();
                        var dashboardWindow = new DashboardWindow(username);
                        dashboardWindow.Print();
                    }
                    else
                    {
                        for (int top = 9; top < 18; top++)
                        {
                            System.Console.SetCursorPosition(30, top);
                            System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                            System.Console.Write(new string(' ', 60));
                        }
                        System.Console.SetCursorPosition(50, 11);
                        System.Console.Write("You are not logged in");
                        System.Console.SetCursorPosition(55, 15);
                        System.Console.BackgroundColor = ConsoleColor.Blue;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.Write("<< GO BACK");
                        System.Console.ReadKey();
                        System.Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                else if (decision == 1)
                {
                    if (_loginService.LogInAsAdmin(username, password).Result)
                    {
                        var adminWindow = new AdminWindow(username);
                        adminWindow.Print();
                    }
                    else
                    {
                        for (int top = 9; top < 18; top++)
                        {
                            System.Console.SetCursorPosition(30, top);
                            System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                            System.Console.Write(new string(' ', 60));
                        }
                        System.Console.SetCursorPosition(50, 11);
                        System.Console.Write("You are not logged in");
                        System.Console.SetCursorPosition(55, 15);
                        System.Console.BackgroundColor = ConsoleColor.Blue;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.Write("<< GO BACK");
                        System.Console.ReadKey();
                        System.Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                else
                {
                    if (_loginService.Register(username, password).Result)
                    {
                        for (int top = 9; top < 18; top++)
                        {
                            System.Console.SetCursorPosition(30, top);
                            System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                            System.Console.Write(new string(' ', 60));
                        }
                        System.Console.SetCursorPosition(55, 11);
                        System.Console.Write("You are registered");
                        System.Console.SetCursorPosition(55, 15);
                        System.Console.BackgroundColor = ConsoleColor.Blue;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.Write("<< GO BACK");
                        System.Console.ReadKey();
                        System.Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        for (int top = 9; top < 18; top++)
                        {
                            System.Console.SetCursorPosition(30, top);
                            System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                            System.Console.Write(new string(' ', 60));
                        }
                        System.Console.SetCursorPosition(50, 11);
                        System.Console.Write("Register error");
                        System.Console.SetCursorPosition(55, 15);
                        System.Console.BackgroundColor = ConsoleColor.Blue;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.Write("<< GO BACK");
                        System.Console.ReadKey();
                        System.Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
            }
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
            System.Console.SetCursorPosition(40, 25);
            System.Console.Write("LOGIN");
            System.Console.SetCursorPosition(50, 25);
            System.Console.Write("LOGIN AS ADMIN");
            System.Console.SetCursorPosition(70, 25);
            System.Console.Write("REGISTER");
            System.Console.CursorVisible = true;
        }

        private static int LogInOrRegister()
        {
            System.Console.CursorVisible = false;
            int i = 0;
            while (true)
            {
                System.Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.ForegroundColor = ConsoleColor.Black;
                if (i == 0)
                {
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.SetCursorPosition(40, 25);
                    System.Console.Write("LOGIN");
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.SetCursorPosition(50, 25);
                    System.Console.Write("LOGIN AS ADMIN");
                    System.Console.SetCursorPosition(70, 25);
                    System.Console.Write("REGISTER");
                }
                else if (i == 1)
                {
                    System.Console.SetCursorPosition(40, 25);
                    System.Console.Write("LOGIN");
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.SetCursorPosition(50, 25);
                    System.Console.Write("LOGIN AS ADMIN");
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.SetCursorPosition(70, 25);
                    System.Console.Write("REGISTER");
                }
                else
                {
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.SetCursorPosition(40, 25);
                    System.Console.Write("LOGIN");
                    System.Console.SetCursorPosition(50, 25);
                    System.Console.Write("LOGIN AS ADMIN");
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.SetCursorPosition(70, 25);
                    System.Console.Write("REGISTER");
                }
                ConsoleKeyInfo cki = System.Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (i > 0) i--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (i < 3) i++;
                        break;
                    case ConsoleKey.Enter:
                        return i;
                    default:
                        break;
                }
            }
        }
    }
}
