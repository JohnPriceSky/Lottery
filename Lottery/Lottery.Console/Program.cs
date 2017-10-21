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
        }
        public static void DrawBorder()
        {
            System.Console.SetWindowSize(120, 30);
            for (int lengthCount = 3; lengthCount < 27; lengthCount++)
            {
                System.Console.SetCursorPosition(3, lengthCount);
                System.Console.Write("|");
                System.Console.SetCursorPosition(116, lengthCount);
                System.Console.Write("|");
            }
            System.Console.SetCursorPosition(4, 2);
            for (int widthCount = 3; widthCount < 59; widthCount++)
            {
                System.Console.Write("- ");
            }
            System.Console.SetCursorPosition(4, 6);
            for (int widthCount = 3; widthCount < 59; widthCount++)
            {
                System.Console.Write("- ");
            }
            System.Console.SetCursorPosition(4, 27);
            for (int widthCount = 3; widthCount < 59; widthCount++)
            {
                System.Console.Write("- ");
            }
        }
    }
}
