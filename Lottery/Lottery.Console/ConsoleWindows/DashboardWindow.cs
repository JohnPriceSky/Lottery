using Lottery.Application.Abstract;
using Lottery.Application.DTO;
using Lottery.Application.Services;
using Lottery.Console.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Console.ConsoleWindows
{
    class DashboardWindow : ConsoleWindow, IConsoleWindow
    {
        private string username;
        private List<LotteryDTO> lotteryList;
        private LotteryService _lotteryService;

        public DashboardWindow(string username)
        {
            this.username = username;
            _lotteryService = new LotteryService();
        }

        public void Print()
        {
            DrawMenu();
            lotteryList = _lotteryService.GetLotteries().Result.ToList();
            DisplayList(lotteryList);
            ChooseLottery(lotteryList);
        }

        private void ChooseLottery(List<LotteryDTO> lotteryList)
        {
            int index = 0;
            while (true)
            {
                index %= lotteryList.Count;
                if (index < 0)
                    DisplayList(lotteryList, index + lotteryList.Count);
                else
                    DisplayList(lotteryList, index);
                ConsoleKeyInfo cki = System.Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.UpArrow:
                        index--;
                        break;
                    case ConsoleKey.Enter:
                        int lotteryDetailIndex;
                        if (index < 0)
                            lotteryDetailIndex = index + lotteryList.Count;
                        else
                            lotteryDetailIndex = index;
                        var lotteryDetailWindow = new LotteryDetailWindow(lotteryList[lotteryDetailIndex]);
                        lotteryDetailWindow.Print();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }

            }
        }

        private void DisplayList(List<LotteryDTO> lotteryList, int index = -1)
        {
            ClearContent();
            int top = 4;
            foreach (var item in lotteryList)
            {
                if (index >= 0 && lotteryList[index] == item)
                    System.Console.BackgroundColor = ConsoleColor.DarkGray;
                else
                    System.Console.BackgroundColor = ConsoleColor.Gray;

                for (int i = 0; i < 3; i++)
                {
                    System.Console.SetCursorPosition(0, top + i);
                    System.Console.Write(new string(' ', 120));
                }
                top++;
                System.Console.SetCursorPosition(6, top);
                System.Console.Write(item.LotteryName);
                System.Console.SetCursorPosition(50, top);
                System.Console.Write("Prize: " + item.Prize);
                System.Console.SetCursorPosition(70, top);
                System.Console.Write("DrowTime: " + item.DrowTime);
                top++;
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
    }
}
