using Lottery.Console.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Console.ConsoleWindows
{
    class DashboardWindow : IConsoleWindow
    {
        private string username;
        private List<string> lotteryList = new List<string>();

        public DashboardWindow(string username)
        {
            this.username = username;
        }

        public void Print()
        {
            DrawMenu();
            lotteryList.Add("Graj o talon");
            lotteryList.Add("Wygraj tapczan na raty");
            lotteryList.Add("Piłka do nadmuchania");
            lotteryList.Add("Złamany grosz");
            DisplayList(lotteryList);
        }

        private void DisplayList(List<string> lotteryList)
        {
            int left = 6, top = 4;
            foreach (var item in lotteryList)
            {
                top++;
                System.Console.SetCursorPosition(left, top++);
                System.Console.Write(item);
                top++;
                System.Console.SetCursorPosition(0, top++);
                System.Console.Write(new string('-', 120));
            }
        }

        private void DrawMenu()
        {
            ClearHeader();
            System.Console.SetCursorPosition(6, 1);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("DASHBOARD");
            System.Console.SetCursorPosition(80, 1);
            System.Console.Write($"Logged as {username}");
            ClearContent();
            System.Console.ForegroundColor = ConsoleColor.Black;

        }

        private void ClearHeader()
        {
            System.Console.BackgroundColor = ConsoleColor.Blue;
            for (int top = 0; top < 3; top++)
            {
                System.Console.SetCursorPosition(0, top);
                System.Console.Write(new string(' ', 120));
            }
        }

        private void ClearContent()
        {
            System.Console.BackgroundColor = ConsoleColor.Gray;
            for (int top = 3; top < 29; top++)
            {
                System.Console.SetCursorPosition(0, top);
                System.Console.Write(new string(' ', 120));
            }
        }
    }
}
