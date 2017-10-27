using Lottery.Application.Services;
using Lottery.Console.ConsoleWindows;
using System;

namespace Lottery.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginService = new LoginService();
            var loginWindow = new LoginWindow(loginService);
            DrawBorder();
            loginWindow.Print();
            System.Console.ReadKey();
        }
        public static void DrawBorder()
        {
            System.Console.SetWindowSize(120, 30); //Content from 4th row

            System.Console.BackgroundColor = ConsoleColor.Blue;
            for (int top = 0; top < 3; top++)
            {
                System.Console.SetCursorPosition(0, top);
                System.Console.Write(new string(' ', 120));
            }
            System.Console.BackgroundColor = ConsoleColor.Gray;
            for (int top = 3; top < 29; top++)
            {
                System.Console.SetCursorPosition(0, top);
                System.Console.Write(new string(' ', 120));
            }
        }
    }
}
